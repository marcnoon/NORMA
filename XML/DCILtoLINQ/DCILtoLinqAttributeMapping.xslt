﻿<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet
	version="1.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:plx="http://schemas.neumont.edu/CodeGeneration/PLiX"
	xmlns:dep="http://schemas.orm.net/DIL/DILEP"
	xmlns:dcl="http://schemas.orm.net/DIL/DCIL"
	xmlns:ddt="http://schemas.orm.net/DIL/DILDT"
	xmlns:orm="http://schemas.neumont.edu/ORM/2006-04/ORMCore"
	xmlns:oial="http://schemas.neumont.edu/ORM/Abstraction/2007-06/Core"
	xmlns:odt="http://schemas.neumont.edu/ORM/Abstraction/2007-06/DataTypes/Core"
	xmlns:ormRoot="http://schemas.neumont.edu/ORM/2006-04/ORMRoot"
	xmlns:ormtooial="http://schemas.neumont.edu/ORM/Bridge/2007-06/ORMToORMAbstraction"
	xmlns:exsl="http://exslt.org/common"
	extension-element-prefixes="exsl dcl orm oial dep odt ormRoot ormtooial ddt"
	>
	<xsl:output indent="yes"/>
	<xsl:param name="GenerateCodeAnalysisAttributes" select="true()"/>
	<xsl:param name="GenerateAccessedThroughPropertyAttribute" select="false()"/>
	<xsl:param name="GenerateObjectDataSourceSupport" select="true()"/>
	<xsl:param name="RaiseEventsAsynchronously" select="true()"/>
	<xsl:param name="SynchronizeEventAddRemove" select="true()"/>
	<xsl:param name="DefaultNamespace" select="'MyNamespace'"/>
	<xsl:param name="PrivateMemberPrefix" select="'_'"/>
	<xsl:variable name="GenerateServiceLayer" select="true()"/>
	<xsl:variable name="GenerateLinqAttributes" select="true()"/>
	<xsl:variable name="CollectionSuffix" select="'Collection'"/>
	<xsl:variable name="TableSuffix" select="'Table'"/>
	<xsl:param name="UseXmlMapping" select="false()"/>
	<xsl:param name="UseAttributeMapping" select="true()"/>
	<xsl:variable name="DcilSchemaName" select="/dcl:schema/@name"/>


	<xsl:template match="/">
		<plx:root>
			<plx:namespaceImport name="System"/>
			<plx:namespaceImport name="System.Collections.Generic"/>
			<plx:namespaceImport name="System.ComponentModel"/>
			<plx:namespaceImport name="System.Data"/>
			<plx:namespaceImport name="System.Data.Linq"/>
			<plx:namespaceImport name="System.Data.Linq.Mapping"/>
			<plx:namespaceImport name="System.Diagnostics.CodeAnalysis"/>
			<plx:namespaceImport name="System.Linq"/>
			<plx:namespaceImport name="System.Runtime.Serialization"/>
			<xsl:if test="$GenerateServiceLayer">
				<plx:namespaceImport name="System.ServiceModel"/>
			</xsl:if>
			<plx:namespaceImport name="System.Threading"/>
			<xsl:apply-templates select="dcl:schema" mode="GenerateNamespace"/>
		</plx:root>
	</xsl:template>

	<xsl:template match="dcl:schema" mode="GenerateNamespace">
		<xsl:variable name="modelName" select="@name"/>
		<xsl:variable name="fullyQualifiedNamespace" select="$DefaultNamespace"/>
		<plx:namespace name="{$fullyQualifiedNamespace}">
			<xsl:if test="$GenerateServiceLayer">
				<xsl:apply-templates select="." mode="GenerateServiceContract">
					<xsl:with-param name="modelName" select="$modelName"/>
				</xsl:apply-templates>
			</xsl:if>
			<xsl:apply-templates select="." mode="GenerateDatabaseContext">
				<xsl:with-param name="modelName" select="$modelName"/>
				<xsl:with-param name="fullyQualifiedNamespace" select="$fullyQualifiedNamespace"/>
			</xsl:apply-templates>
			<!--Generate Enumerations for any ValueConstraints that qualify. -->
			<xsl:apply-templates select="dcl:domain[dcl:predefinedDataType/@name = 'CHARACTER VARYING' or dcl:predefinedDataType/@name = 'CHARACTER' or dcl:predefinedDataType/@name = 'CHARACTER LARGE OBJECT' and count(dcl:checkConstraint) = 1 and count(dcl:checkConstraint/dep:inPredicate) = 1 and dcl:checkConstraint/dep:inPredicate/@type='IN']" mode="GenerateEnumerations"/>
			<xsl:apply-templates select="dcl:table" mode="GenerateBusinessEntities">
			</xsl:apply-templates>
			<xsl:call-template name="GenerateGlobalSupportClasses"/>
		</plx:namespace>
	</xsl:template>

	<xsl:template match="dcl:schema" mode="GenerateServiceContract">
		<xsl:param name="modelName" select="@name"/>
		<xsl:if test="$GenerateServiceLayer">
			<plx:interface visibility="public" name="I{$modelName}Service">
				<plx:attribute dataTypeName="ServiceContractAttribute"/>
				<xsl:for-each select="dcl:table">
					<plx:pragma type="region">
						<xsl:attribute name="data">
							<xsl:text>Create, Read, Update, and Delete Operations for </xsl:text>
							<xsl:value-of select="@name"/>
						</xsl:attribute>
					</plx:pragma>
					<plx:function name="Create{@name}">
						<plx:attribute dataTypeName="OperationContract"/>
					</plx:function>
					<plx:function name="Read{@name}">
						<plx:attribute dataTypeName="OperationContract"/>
					</plx:function>
					<plx:function name="Update{@name}">
						<plx:attribute dataTypeName="OperationContract"/>
					</plx:function>
					<plx:function name="Delete{@name}">
						<plx:attribute dataTypeName="OperationContract"/>
					</plx:function>
					<plx:pragma type="closeRegion">
						<xsl:attribute name="data">
							<xsl:text>CRUD Operation for</xsl:text>
							<xsl:value-of select="@name"/>
						</xsl:attribute>
					</plx:pragma>
				</xsl:for-each>
			</plx:interface>
		</xsl:if>
	</xsl:template>

	<xsl:template match="dcl:table" mode="GenerateBusinessEntities">
		<xsl:variable name="tableName" select="@name"/>
		<plx:class visibility="public" name="{$tableName}">
			<plx:implementsInterface dataTypeName="INotifyPropertyChanging"/>
			<plx:implementsInterface dataTypeName="INotifyPropertyChanged" />
			<xsl:if test="$GenerateServiceLayer">
				<plx:attribute dataTypeName="DataContract">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Name"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$tableName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<xsl:if test="$GenerateLinqAttributes">
				<plx:attribute dataTypeName="Table">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Name"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$DcilSchemaName}.{$tableName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<xsl:variable name="containingConceptType" select="."/>
			<plx:function name=".construct" visibility="public">
				<xsl:for-each select="../dcl:table[dcl:referenceConstraint/@targetTable = current()/@name]">
					<xsl:variable name="entitySetTableName" select="@name"/>
					<plx:assign>
						<plx:left>
							<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}{$entitySetTableName}"/>
						</plx:left>
						<plx:right>
							<plx:callNew dataTypeName="EntitySet">
								<plx:passTypeParam dataTypeName="{$entitySetTableName}"/>
								<plx:passParam>
									<plx:callNew dataTypeName="Action">
										<plx:passTypeParam dataTypeName="{$entitySetTableName}"/>
										<plx:passParam>
											<plx:callThis accessor="this" name="On{$entitySetTableName}Added" type="fireCustomEvent"/>
										</plx:passParam>
									</plx:callNew>
								</plx:passParam>
								<plx:passParam>
									<plx:callNew dataTypeName="Action">
										<plx:passTypeParam dataTypeName="{$entitySetTableName}"/>
										<plx:passParam>
											<plx:callThis accessor="this" type="fireCustomEvent" name="On{$entitySetTableName}Removed"/>
										</plx:passParam>
									</plx:callNew>
								</plx:passParam>
							</plx:callNew>
						</plx:right>
					</plx:assign>
				</xsl:for-each>
			</plx:function>
			<plx:pragma type="region" data="Event Binding Information for INotifyPropertyChanging and INotifyPropertyChanged"/>
			<xsl:call-template name="GenerateINotifyPropertyChangingImplementation"/>
			<xsl:call-template name="GenerateINotifyPropertyChangedImplementation"/>
			<plx:pragma type="closeRegion" data="Databinding Information for INotifyPropertyChanging and INotifyPropertyChanged"/>
			<xsl:apply-templates select="child::*" mode="GenerateEntityMembers"/>
			<xsl:for-each select="../dcl:table[dcl:referenceConstraint/@targetTable = current()/@name]">
				<xsl:apply-templates select="." mode="GenerateEntitySetMembers">
					<xsl:with-param name="containingConceptType" select="$containingConceptType"/>
				</xsl:apply-templates>
			</xsl:for-each>
			<xsl:if test="$GenerateServiceLayer">
				<plx:function visibility="private" name="On{@name}Serializing">
					<plx:attribute dataTypeName="OnSerializing"
				</plx:function>
				<!--[OnDeserializing()]
				[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
				public void OnDeserializing(StreamingContext context)
				{
				this.Initialize();
				}

				[OnSerializing()]
				[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
				public void OnSerializing(StreamingContext context)
				{
				this.serializing = true;
				}

				[OnSerialized()]
				[System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
				public void OnSerialized(StreamingContext context)
				{
				this.serializing = false;
				}-->
			</xsl:if>
		</plx:class>
	</xsl:template>

	<xsl:template match="dcl:table" mode="GenerateEntitySetMembers">
		<xsl:param name="containingConceptType"/>
		<xsl:variable name="preferredIdentifierInformationTypesFragment">
			<xsl:apply-templates select="$containingConceptType" mode="GetInformationTypesForPreferredIdentifier"/>
		</xsl:variable>
		<xsl:variable name="conceptTypeName" select="@name"/>
		<xsl:variable name="oppositeRoleName" select="@name"/>
		<xsl:variable name="privateMemberName" select="concat($PrivateMemberPrefix,$conceptTypeName)"/>
		<plx:field visibility="private" static="true" readOnly="true" dataTypeName="PropertyChangingEventArgs" name="{$conceptTypeName}PropertyChangingEventArgs">
			<plx:initialize>
				<plx:callNew dataTypeName="PropertyChangingEventArgs">
					<plx:passParam>
						<plx:string data="{$oppositeRoleName}"/>
					</plx:passParam>
				</plx:callNew>
			</plx:initialize>
		</plx:field>
		<plx:field visibility="private" static="true" readOnly="true" dataTypeName="PropertyChangedEventArgs" name="{$conceptTypeName}PropertyChangedEventArgs">
			<plx:initialize>
				<plx:callNew dataTypeName="PropertyChangedEventArgs">
					<plx:passParam>
						<plx:string data="{$oppositeRoleName}"/>
					</plx:passParam>
				</plx:callNew>
			</plx:initialize>
		</plx:field>
		<plx:field visibility="private" dataTypeName="EntitySet" name="{$privateMemberName}">
			<plx:passTypeParam dataTypeName="{$conceptTypeName}"/>
		</plx:field>
		<plx:property visibility="public" name="{$oppositeRoleName}">
			<xsl:if test="$GenerateServiceLayer">
				<plx:attribute dataTypeName="DataMember">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Name"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$oppositeRoleName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<xsl:if test="$GenerateLinqAttributes">
				<plx:attribute dataTypeName="Association">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Storage"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$privateMemberName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="OtherKey"/>
							</plx:left>
							<plx:right>
								<plx:string>
									<!--TODO: Set this via a settings file.-->
									<xsl:for-each select="$containingConceptType/dcl:uniquenessConstraint[@isPrimary = 'true' or @isPrimary = 1]/dcl:columnRef">
										<xsl:value-of select="concat(translate(substring(@name, 1, 1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'), substring(@name, 2))"/>
										<xsl:if test="position() != last()">
											<xsl:text>,</xsl:text>
										</xsl:if>
									</xsl:for-each>
								</plx:string>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<plx:returns dataTypeName="EntitySet">
				<plx:passTypeParam dataTypeName="{$conceptTypeName}"/>
			</plx:returns>
			<plx:get>
				<plx:return>
					<plx:callThis accessor="this" type="field" name="{$privateMemberName}"/>
				</plx:return>
			</plx:get>
			<plx:set>
				<plx:callInstance type="methodCall" name="Assign">
					<plx:callObject>
						<plx:callThis name="{$privateMemberName}" accessor="this" type="field"/>
					</plx:callObject>
					<plx:passParam>
						<plx:valueKeyword/>
					</plx:passParam>
				</plx:callInstance>
			</plx:set>
		</plx:property>
		<plx:function visibility="private" name="On{$conceptTypeName}Added">
			<plx:param dataTypeName="{$conceptTypeName}" name="entity"/>
			<plx:callThis accessor="this" name="OnPropertyChanging">
				<plx:passParam>
					<plx:callThis accessor="static" type="field" name="{$conceptTypeName}PropertyChangingEventArgs"/>
				</plx:passParam>
			</plx:callThis>
			<plx:assign>
				<plx:left>
					<plx:callInstance type="property" name="{$containingConceptType/@name}">
						<plx:callObject>
							<plx:nameRef name="entity" type="parameter"/>
						</plx:callObject>
					</plx:callInstance>
				</plx:left>
				<plx:right>
					<plx:thisKeyword/>
				</plx:right>
			</plx:assign>
			<plx:callThis accessor="this" name="OnPropertyChanged">
				<plx:passParam>
					<plx:callThis accessor="static" type="field" name="{$conceptTypeName}PropertyChangedEventArgs"/>
				</plx:passParam>
			</plx:callThis>
		</plx:function>
		<plx:function visibility="private" name="On{$conceptTypeName}Removed">
			<plx:param dataTypeName="{$conceptTypeName}" name="entity"/>
			<plx:callThis accessor="this" name="OnPropertyChanging">
				<plx:passParam>
					<plx:callThis accessor="static" type="field" name="{$conceptTypeName}PropertyChangingEventArgs"/>
				</plx:passParam>
			</plx:callThis>
			<plx:assign>
				<plx:left>
					<plx:callInstance type="property" name="{$containingConceptType/@name}">
						<plx:callObject>
							<plx:nameRef name="entity" type="parameter"/>
						</plx:callObject>
					</plx:callInstance>
				</plx:left>
				<plx:right>
					<plx:nullKeyword/>
				</plx:right>
			</plx:assign>
			<plx:callThis accessor="this" name="OnPropertyChanged">
				<plx:passParam>
					<plx:callThis accessor="static" type="field" name="{$conceptTypeName}PropertyChangedEventArgs"/>
				</plx:passParam>
			</plx:callThis>
		</plx:function>
	</xsl:template>

	<xsl:template match="dcl:column" mode="GenerateEntityMembers">
		<xsl:variable name="informationTypeName" select="@name"/>
		<plx:field visibility="private" static="true" readOnly="true" dataTypeName="PropertyChangingEventArgs" name="{$informationTypeName}PropertyChangingEventArgs">
			<plx:initialize>
				<plx:callNew dataTypeName="PropertyChangingEventArgs">
					<plx:passParam>
						<plx:string data="{concat(translate(substring($informationTypeName, 1, 1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'), substring($informationTypeName, 2))}"/>
					</plx:passParam>
				</plx:callNew>
			</plx:initialize>
		</plx:field>
		<plx:field visibility="private" static="true" readOnly="true" dataTypeName="PropertyChangedEventArgs" name="{$informationTypeName}PropertyChangedEventArgs">
			<plx:initialize>
				<plx:callNew dataTypeName="PropertyChangedEventArgs">
					<plx:passParam>
						<plx:string data="{concat(translate(substring($informationTypeName, 1, 1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'), substring($informationTypeName, 2))}"/>
					</plx:passParam>
				</plx:callNew>
			</plx:initialize>
		</plx:field>
		<plx:field visibility="private" name="{$PrivateMemberPrefix}{$informationTypeName}">
			<xsl:choose>
				<xsl:when test="(@isNullable = 'true' or @isNullable = 1) and not(dcl:predefinedDataType/@name = 'CHARACTER VARYING') and not(dcl:predefinedDataType/@name = 'CHARACTER') and not(dcl:predefinedDataType/@name = 'CHARACTER LARGE OBJECT')">
					<xsl:attribute name="dataTypeName">
						<xsl:value-of select="'Nullable'"/>
					</xsl:attribute>
					<plx:passTypeParam>
						<xsl:choose>
							<xsl:when test="dcl:domainRef[@name = /dcl:schema/dcl:domain[dcl:predefinedDataType/@name = 'CHARACTER VARYING' or dcl:predefinedDataType/@name = 'CHARACTER' or dcl:predefinedDataType/@name = 'CHARACTER LARGE OBJECT' and count(dcl:checkConstraint) = 1 and count(dcl:checkConstraint/dep:inPredicate) = 1 and dcl:checkConstraint/dep:inPredicate/@type='IN']/@name]">
								<xsl:attribute name="dataTypeName">
									<xsl:value-of select="dcl:domainRef/@name"/>
								</xsl:attribute>
							</xsl:when>
							<xsl:otherwise>
								<xsl:attribute name="dataTypeName">
									<xsl:call-template name="GetDotNetTypeFromDcilPredefinedDataType">
										<xsl:with-param name="predefinedDataType" select="dcl:predefinedDataType"/>
										<xsl:with-param name="column" select="."/>
									</xsl:call-template>
								</xsl:attribute>
							</xsl:otherwise>
						</xsl:choose>
					</plx:passTypeParam>
				</xsl:when>
				<xsl:otherwise>
					<xsl:choose>
						<xsl:when test="dcl:domainRef[@name = /dcl:schema/dcl:domain[dcl:predefinedDataType/@name = 'CHARACTER VARYING' or dcl:predefinedDataType/@name = 'CHARACTER' or dcl:predefinedDataType/@name = 'CHARACTER LARGE OBJECT' and count(dcl:checkConstraint) = 1 and count(dcl:checkConstraint/dep:inPredicate) = 1 and dcl:checkConstraint/dep:inPredicate/@type='IN']/@name]">
							<xsl:attribute name="dataTypeName">
								<xsl:value-of select="dcl:domainRef/@name"/>
							</xsl:attribute>
						</xsl:when>
						<xsl:otherwise>
							<xsl:attribute name="dataTypeName">
								<xsl:call-template name="GetDotNetTypeFromDcilPredefinedDataType">
									<xsl:with-param name="predefinedDataType" select="dcl:predefinedDataType"/>
									<xsl:with-param name="column" select="."/>
								</xsl:call-template>
							</xsl:attribute>
						</xsl:otherwise>
					</xsl:choose>
				</xsl:otherwise>
			</xsl:choose>
		</plx:field>
		<plx:property visibility="public" name="{concat(translate(substring($informationTypeName, 1, 1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'), substring($informationTypeName, 2))}">
			<xsl:if test="$GenerateServiceLayer">
				<xsl:if test="not(../dcl:referenceConstraint/dcl:columnRef/@sourceName = current()/@name)">
					<plx:attribute dataTypeName="DataMember">
						<plx:passParam>
							<plx:binaryOperator type="assignNamed">
								<plx:left>
									<plx:nameRef name="Name"/>
								</plx:left>
								<plx:right>
									<!--TODO: Set this via a settings file.-->
									<plx:string data="{$informationTypeName}"/>
								</plx:right>
							</plx:binaryOperator>
						</plx:passParam>
						<plx:passParam>
							<plx:binaryOperator type="assignNamed">
								<plx:left>
									<plx:nameRef name="IsRequired"/>
								</plx:left>
								<plx:right>
									<!--TODO: Set this via a settings file.-->
									<xsl:choose>
										<xsl:when test="@isNullable = 'false' or @isNullable = 0">
											<plx:trueKeyword/>
										</xsl:when>
										<xsl:otherwise>
											<plx:falseKeyword/>
										</xsl:otherwise>
									</xsl:choose>
								</plx:right>
							</plx:binaryOperator>
						</plx:passParam>
					</plx:attribute>
				</xsl:if>
			</xsl:if>
			<xsl:if test="$GenerateLinqAttributes">
				<plx:attribute dataTypeName="Column">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Storage"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$PrivateMemberPrefix}{$informationTypeName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="CanBeNull"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<xsl:choose>
									<xsl:when test="@isNullable = 'false' or @isNullable = 0">
										<plx:falseKeyword/>
									</xsl:when>
									<xsl:otherwise>
										<plx:trueKeyword/>
									</xsl:otherwise>
								</xsl:choose>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
					<xsl:if test="../dcl:uniquenessConstraint[@isPrimary='true' or @IsPrimary = 1]/dcl:columnRef[@name = current()/@name]">
						<plx:passParam>
							<plx:binaryOperator type="assignNamed">
								<plx:left>
									<plx:nameRef name="IsPrimaryKey"/>
								</plx:left>
								<plx:right>
									<!--TODO: Set this via a settings file.-->
									<plx:trueKeyword/>
								</plx:right>
							</plx:binaryOperator>
						</plx:passParam>
					</xsl:if>
					<xsl:if test="@isIdentity = 'true' or @isIdentity = 1">
						<plx:passParam>
							<plx:binaryOperator type="assignNamed">
								<plx:left>
									<plx:nameRef name="IsDbGenerated"/>
								</plx:left>
								<plx:right>
									<!--TODO: Set this via a settings file.-->
									<plx:trueKeyword/>
								</plx:right>
							</plx:binaryOperator>
						</plx:passParam>
					</xsl:if>
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="DbType"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string>
									<xsl:attribute name="data">
										<xsl:choose>
											<xsl:when test="dcl:predefinedDataType">
												<xsl:call-template name="GetDbTypeFromDcilPredefinedDataType">
													<xsl:with-param name="predefinedDataType" select="dcl:predefinedDataType"/>
													<xsl:with-param name="column" select="."/>
												</xsl:call-template>
											</xsl:when>
											<xsl:when test="dcl:domainRef">
												<xsl:variable name="domainPredefinedDataType" select="/dcl:schema/dcl:domain[@name = current()/dcl:domainRef/@name]/dcl:predefinedDataType"/>
												<xsl:call-template name="GetDbTypeFromDcilPredefinedDataType">
													<xsl:with-param name="predefinedDataType" select="$domainPredefinedDataType"/>
													<xsl:with-param name="column" select="."/>
												</xsl:call-template>
											</xsl:when>
											<xsl:otherwise>
												<xsl:message terminate="yes">SANITY CHECK: A Column should always havea predefinedDataType or a domainRef.</xsl:message>
											</xsl:otherwise>
										</xsl:choose>
									</xsl:attribute>
								</plx:string>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<plx:returns>
				<xsl:choose>
					<xsl:when test="(@isNullable = 'true' or @isNullable = 1) and not(dcl:predefinedDataType/@name = 'CHARACTER VARYING') and not(dcl:predefinedDataType/@name = 'CHARACTER') and not(dcl:predefinedDataType/@name = 'CHARACTER LARGE OBJECT')">
						<xsl:attribute name="dataTypeName">
							<xsl:value-of select="'Nullable'"/>
						</xsl:attribute>
						<plx:passTypeParam>
							<xsl:choose>
								<xsl:when test="dcl:domainRef[@name = /dcl:schema/dcl:domain[dcl:predefinedDataType/@name = 'CHARACTER VARYING' or dcl:predefinedDataType/@name = 'CHARACTER' or dcl:predefinedDataType/@name = 'CHARACTER LARGE OBJECT' and count(dcl:checkConstraint) = 1 and count(dcl:checkConstraint/dep:inPredicate) = 1 and dcl:checkConstraint/dep:inPredicate/@type='IN']/@name]">
									<xsl:attribute name="dataTypeName">
										<xsl:value-of select="dcl:domainRef/@name"/>
									</xsl:attribute>
								</xsl:when>
								<xsl:otherwise>
									<xsl:attribute name="dataTypeName">
										<xsl:call-template name="GetDotNetTypeFromDcilPredefinedDataType">
											<xsl:with-param name="predefinedDataType" select="dcl:predefinedDataType"/>
											<xsl:with-param name="column" select="."/>
										</xsl:call-template>
									</xsl:attribute>
								</xsl:otherwise>
							</xsl:choose>
						</plx:passTypeParam>
					</xsl:when>
					<xsl:otherwise>
						<xsl:choose>
							<xsl:when test="dcl:domainRef[@name = /dcl:schema/dcl:domain[dcl:predefinedDataType/@name = 'CHARACTER VARYING' or dcl:predefinedDataType/@name = 'CHARACTER' or dcl:predefinedDataType/@name = 'CHARACTER LARGE OBJECT' and count(dcl:checkConstraint) = 1 and count(dcl:checkConstraint/dep:inPredicate) = 1 and dcl:checkConstraint/dep:inPredicate/@type='IN']/@name]">
								<xsl:attribute name="dataTypeName">
									<xsl:value-of select="dcl:domainRef/@name"/>
								</xsl:attribute>
							</xsl:when>
							<xsl:otherwise>
								<xsl:attribute name="dataTypeName">
									<xsl:call-template name="GetDotNetTypeFromDcilPredefinedDataType">
										<xsl:with-param name="predefinedDataType" select="dcl:predefinedDataType"/>
										<xsl:with-param name="column" select="."/>
									</xsl:call-template>
								</xsl:attribute>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:otherwise>
				</xsl:choose>
			</plx:returns>
			<plx:get>
				<plx:return>
					<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}{$informationTypeName}" />
				</plx:return>
			</plx:get>
			<plx:set>
				<!--<xsl:if test="@isMandatory">
					<plx:branch>
						<plx:condition>
							<plx:binaryOperator type="identityEquality">
								<plx:left>
									<plx:valueKeyword/>
								</plx:left>
								<plx:right>
									<plx:nullKeyword/>
								</plx:right>
							</plx:binaryOperator>
						</plx:condition>
						<plx:throw>
							<plx:callNew dataTypeName="ArgumentNullException"/>
						</plx:throw>
					</plx:branch>
				</xsl:if>-->
				<plx:branch>
					<plx:condition>
						<plx:binaryOperator type="identityInequality">
							<plx:left>
								<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}{$informationTypeName}" />
							</plx:left>
							<plx:right>
								<plx:valueKeyword/>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:callThis accessor="this" type="methodCall" name="OnPropertyChanging">
						<plx:passParam>
							<plx:nameRef name="{$informationTypeName}PropertyChangingEventArgs"/>
						</plx:passParam>
					</plx:callThis>
					<plx:assign>
						<plx:left>
							<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}{$informationTypeName}" />
						</plx:left>
						<plx:right>
							<plx:valueKeyword/>
						</plx:right>
					</plx:assign>
					<plx:callThis accessor="this" type="methodCall" name="OnPropertyChanged">
						<plx:passParam>
							<plx:nameRef name="{$informationTypeName}PropertyChangedEventArgs"/>
						</plx:passParam>
					</plx:callThis>
				</plx:branch>
			</plx:set>
		</plx:property>
	</xsl:template>

	<xsl:template match="dcl:referenceConstraint" mode="GenerateEntityMembers">
		<xsl:variable name="conceptTypeName" select="@targetTable"/>
		<xsl:variable name="privateMemberName" select="concat($PrivateMemberPrefix,$conceptTypeName)"/>
		<plx:field visibility="private" static="true" readOnly="true" dataTypeName="PropertyChangingEventArgs" name="{$conceptTypeName}PropertyChangingEventArgs">
			<plx:initialize>
				<plx:callNew dataTypeName="PropertyChangingEventArgs">
					<plx:passParam>
						<plx:string data="{$conceptTypeName}"/>
					</plx:passParam>
				</plx:callNew>
			</plx:initialize>
		</plx:field>
		<plx:field visibility="private" static="true" readOnly="true" dataTypeName="PropertyChangedEventArgs" name="{$conceptTypeName}PropertyChangedEventArgs">
			<plx:initialize>
				<plx:callNew dataTypeName="PropertyChangedEventArgs">
					<plx:passParam>
						<plx:string data="{$conceptTypeName}"/>
					</plx:passParam>
				</plx:callNew>
			</plx:initialize>
		</plx:field>
		<plx:field visibility="private" dataTypeName="EntityRef" name="{$privateMemberName}">
			<plx:passTypeParam dataTypeName="{$conceptTypeName}"/>
		</plx:field>
		<plx:property visibility="public" name="{$conceptTypeName}">
			<xsl:if test="$GenerateServiceLayer">
				<plx:attribute dataTypeName="DataMember">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Name"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$conceptTypeName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="IsRequired"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<xsl:choose>
									<xsl:when test="@isNullable = 'true' or @isNullable = 1">
										<plx:falseKeyword/>
									</xsl:when>
									<xsl:otherwise>
										<plx:trueKeyword/>
									</xsl:otherwise>
								</xsl:choose>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<xsl:if test="$GenerateLinqAttributes">
				<plx:attribute dataTypeName="Association">
					<!-- TODO: Determin what we should do with: DeleteOnNull, DeleteRule, IsUnique, TypeId, Name -->
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Storage"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$privateMemberName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="IsForeignKey"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:trueKeyword/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="ThisKey"/>
							</plx:left>
							<plx:right>
								<plx:string>
									<xsl:for-each select="dcl:columnRef">
										<xsl:value-of select="concat(translate(substring(@sourceName, 1, 1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'), substring(@sourceName, 2))"/>
										<xsl:if test="position() != last()">
											<xsl:text>,</xsl:text>
										</xsl:if>
									</xsl:for-each>
								</plx:string>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<plx:returns dataTypeName="{$conceptTypeName}"/>
			<plx:get>
				<plx:return>
					<plx:callInstance type="property" name="Entity">
						<plx:callObject>
							<plx:callThis accessor="this" type="field" name="{$privateMemberName}"/>
						</plx:callObject>
					</plx:callInstance>
				</plx:return>
			</plx:get>
			<plx:set>
				<!--<xsl:if test="@isNullable = 'false' or @isNullable = 0">
					<plx:branch>
						<plx:condition>
							<plx:binaryOperator type="identityEquality">
								<plx:left>
									<plx:valueKeyword/>
								</plx:left>
								<plx:right>
									<plx:nullKeyword/>
								</plx:right>
							</plx:binaryOperator>
						</plx:condition>
						<plx:throw>
							<plx:callNew dataTypeName="ArgumentNullException"/>
						</plx:throw>
					</plx:branch>
				</xsl:if>-->
				<plx:local name="previousValue" dataTypeName="{$conceptTypeName}">
					<plx:initialize>
						<plx:callInstance type="property" name="Entity">
							<plx:callObject>
								<plx:callThis accessor="this" type="field" name="{$privateMemberName}"/>
							</plx:callObject>
						</plx:callInstance>
					</plx:initialize>
				</plx:local>
				<plx:branch>
					<plx:condition>
						<plx:binaryOperator type="booleanOr">
							<plx:left>
								<plx:unaryOperator type="booleanNot">
									<plx:callInstance type="property" name="HasLoadedOrAssignedValue">
										<plx:callObject>
											<plx:callThis type="field" accessor="this" name="{$privateMemberName}"/>
										</plx:callObject>
									</plx:callInstance>
								</plx:unaryOperator>
							</plx:left>
							<plx:right>
								<plx:binaryOperator type="inequality">
									<plx:left>
										<plx:nameRef name="previousValue"/>
									</plx:left>
									<plx:right>
										<plx:valueKeyword/>
									</plx:right>
								</plx:binaryOperator>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:callThis accessor="this" name="OnPropertyChanging">
						<plx:passParam>
							<plx:callThis accessor="static" type="field" name="{$conceptTypeName}PropertyChangingEventArgs"/>
						</plx:passParam>
					</plx:callThis>
					<plx:branch>
						<plx:condition>
							<plx:binaryOperator type="inequality">
								<plx:left>
									<plx:nameRef name="previousValue"/>
								</plx:left>
								<plx:right>
									<plx:nullKeyword/>
								</plx:right>
							</plx:binaryOperator>
						</plx:condition>
						<plx:assign>
							<plx:left>
								<plx:callInstance type="property" name="Entity">
									<plx:callObject>
										<plx:callThis type="field" name="{$privateMemberName}" accessor="this"/>
									</plx:callObject>
								</plx:callInstance>
							</plx:left>
							<plx:right>
								<plx:nullKeyword/>
							</plx:right>
						</plx:assign>
						<plx:callInstance type="methodCall" name="Remove">
							<plx:callObject>
								<plx:callInstance type="property" name="{../@name}">
									<plx:callObject>
										<plx:nameRef name="previousValue"/>
									</plx:callObject>
								</plx:callInstance>
							</plx:callObject>
							<plx:passParam>
								<plx:thisKeyword/>
							</plx:passParam>
						</plx:callInstance>
					</plx:branch>
					<plx:assign>
						<plx:left>
							<plx:callInstance type="property" name="Entity">
								<plx:callObject>
									<plx:callThis accessor="this" type="field" name="{$privateMemberName}"/>
								</plx:callObject>
							</plx:callInstance>
						</plx:left>
						<plx:right>
							<plx:valueKeyword/>
						</plx:right>
					</plx:assign>
					<plx:branch>
						<plx:condition>
							<plx:binaryOperator type="inequality">
								<plx:left>
									<plx:valueKeyword/>
								</plx:left>
								<plx:right>
									<plx:nullKeyword/>
								</plx:right>
							</plx:binaryOperator>
						</plx:condition>
						<plx:callInstance type="methodCall" name="Add">
							<plx:callObject>
								<plx:callInstance type="property" name="{../@name}">
									<plx:callObject>
										<plx:valueKeyword/>
									</plx:callObject>
								</plx:callInstance>
							</plx:callObject>
							<plx:passParam>
								<plx:thisKeyword/>
							</plx:passParam>
						</plx:callInstance>
						<xsl:for-each select="dcl:columnRef">
							<plx:assign>
								<plx:left>
									<plx:callThis accessor="this" type="field" name="{concat(translate(substring(@sourceName, 1, 1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'), substring(@sourceName, 2))}"/>
								</plx:left>
								<plx:right>
									<plx:callInstance type="field" name="{concat(translate(substring(@targetName, 1, 1), 'abcdefghijklmnopqrstuvwxyz', 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'), substring(@targetName, 2))}">
										<plx:callObject>
											<plx:valueKeyword/>
										</plx:callObject>
									</plx:callInstance>
								</plx:right>
							</plx:assign>
						</xsl:for-each>
					</plx:branch>
					<plx:callThis accessor="this" name="OnPropertyChanged">
						<plx:passParam>
							<plx:callThis accessor="static" type="field" name="{$conceptTypeName}PropertyChangedEventArgs"/>
						</plx:passParam>
					</plx:callThis>
				</plx:branch>
			</plx:set>
		</plx:property>
	</xsl:template>

	<xsl:template match="dcl:domain" mode="GenerateEnumerations">
		<xsl:param name="enumName" select="@name"/>
		<plx:enum visibility="public" name="{$enumName}">
			<plx:attribute dataTypeName="Serializable"/>
			<xsl:if test="$GenerateServiceLayer">
				<plx:attribute dataTypeName="DataContract">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef name="Name"/>
							</plx:left>
							<plx:right>
								<!--TODO: Set this via a settings file.-->
								<plx:string data="{$enumName}"/>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</plx:attribute>
			</xsl:if>
			<xsl:for-each select="dcl:checkConstraint/dep:inPredicate/ddt:characterStringLiteral">
				<xsl:variable name="enumItem" select="@value"/>
				<plx:enumItem name="{$enumItem}">
					<xsl:if test="$GenerateServiceLayer">
						<plx:attribute dataTypeName="EnumMember">
							<plx:passParam>
								<plx:binaryOperator type="assignNamed">
									<plx:left>
										<plx:nameRef name="Value"/>
									</plx:left>
									<plx:right>
										<!--TODO: Set this via a settings file.-->
										<plx:string data="{$enumItem}"/>
									</plx:right>
								</plx:binaryOperator>
							</plx:passParam>
						</plx:attribute>
					</xsl:if>
				</plx:enumItem>
			</xsl:for-each>
		</plx:enum>
	</xsl:template>

	<xsl:template match="dcl:schema" mode="GenerateDatabaseContext">
		<xsl:param name="modelName" select="@name"/>
		<xsl:param name="fullyQualifiedNamespace"/>
		<plx:class visibility="public" name="{$modelName}">
			<plx:derivesFromClass dataTypeName="DataContext"/>
			<xsl:if test="$GenerateServiceLayer">
				<plx:implementsInterface dataTypeName="I{$modelName}Service"/>
			</xsl:if>
			<plx:field visibility="private" static="true" name="mappingSource" dataTypeName="MappingSource">
				<plx:initialize>
					<xsl:choose>
						<xsl:when test="$UseAttributeMapping">
							<plx:callNew dataTypeName="AttributeMappingSource"/>
						</xsl:when>
						<xsl:when test="$UseXmlMapping">
							<plx:callNew dataTypeName="XmlMappingSource"/>
						</xsl:when>
						<xsl:otherwise>
							<xsl:message terminate="yes">Must specify the type of MappingSource being used.</xsl:message>
						</xsl:otherwise>
					</xsl:choose>
				</plx:initialize>
			</plx:field>
			<plx:function name=".construct" visibility="public">
				<xsl:variable name="firstConstructorParameter" select="'connection'"/>
				<plx:param name="{$firstConstructorParameter}" dataTypeName="IDbConnection"/>
				<plx:initialize>
					<plx:callThis name=".implied" accessor="base">
						<plx:passParam>
							<plx:nameRef name="{$firstConstructorParameter}" type="parameter"/>
						</plx:passParam>
					</plx:callThis>
				</plx:initialize>
			</plx:function>
			<plx:function name=".construct" visibility="public">
				<xsl:variable name="secondConstructorParameter" select="'fileOrServerConnection'"/>
				<plx:param name="{$secondConstructorParameter}" dataTypeName="string"/>
				<plx:initialize>
					<plx:callThis name=".implied" accessor="base">
						<plx:passParam>
							<plx:nameRef name="{$secondConstructorParameter}" type="parameter"/>
						</plx:passParam>
					</plx:callThis>
				</plx:initialize>
			</plx:function>
			<plx:function name=".construct" visibility="public">
				<plx:param name="connection" dataTypeName="IDbConnection"/>
				<plx:param name="mapping" dataTypeName="MappingSource"/>
				<plx:initialize>
					<plx:callThis name=".implied" accessor="base">
						<plx:passParam>
							<plx:nameRef name="connection" type="parameter"/>
						</plx:passParam>
						<plx:passParam>
							<plx:nameRef name="mapping" type="parameter"/>
						</plx:passParam>
					</plx:callThis>
				</plx:initialize>
			</plx:function>
			<plx:function name=".construct" visibility="public">
				<plx:param name="fileOrServerOrConnection" dataTypeName=".string"/>
				<plx:param name="mapping" dataTypeName="MappingSource"/>
				<plx:initialize>
					<plx:callThis name=".implied" accessor="base">
						<plx:passParam>
							<plx:nameRef name="fileOrServerOrConnection" type="parameter"/>
						</plx:passParam>
						<plx:passParam>
							<plx:nameRef name="mapping" type="parameter"/>
						</plx:passParam>
					</plx:callThis>
				</plx:initialize>
			</plx:function>
			<xsl:apply-templates select="dcl:table" mode="CreateDatabaseContextTableAccessorProperties"/>
			<!--Create procedure calls for all procedures.-->
		</plx:class>
	</xsl:template>

	<xsl:template match="dcl:table" mode="CreateDatabaseContextTableAccessorProperties">
		<xsl:variable name="tableName" select="@name"/>
		<plx:property name="{$tableName}{$TableSuffix}" visibility="public">
			<plx:returns dataTypeName="Table">
				<plx:passTypeParam dataTypeName="{$tableName}"/>
			</plx:returns>
			<plx:get>
				<plx:return>
					<plx:callThis accessor="this" name="GetTable">
						<plx:passMemberTypeParam dataTypeName="{$tableName}"/>
					</plx:callThis>
				</plx:return>
			</plx:get>
		</plx:property>
	</xsl:template>

	<xsl:template name="GenerateINotifyPropertyChangedImplementation">
		<plx:field visibility="private" name="{$PrivateMemberPrefix}propertyChangedEventHandler" dataTypeName="PropertyChangedEventHandler"/>
		<plx:event visibility="privateInterfaceMember" name="PropertyChanged">
			<!-- Suppress the 'InterfaceMethodsShouldBeCallableByChildTypes' FxCop warning, since it is not applicable here. -->
			<!-- Child types call the property-specific notification methods, which in turn raise the INotifyPropertyChanged.PropertyChanged event. -->
			<xsl:call-template name="GenerateSuppressMessageAttribute">
				<xsl:with-param name="category" select="'Microsoft.Design'"/>
				<xsl:with-param name="checkId" select="'CA1033:InterfaceMethodsShouldBeCallableByChildTypes'"/>
			</xsl:call-template>
			<plx:interfaceMember memberName="PropertyChanged" dataTypeName="INotifyPropertyChanged"/>
			<plx:param name="sender" dataTypeName=".object"/>
			<plx:param name="e" dataTypeName="PropertyChangedEventArgs"/>
			<plx:explicitDelegateType dataTypeName="PropertyChangedEventHandler"/>
			<plx:onAdd>
				<xsl:call-template name="GetINotifyPropertyChangedImplementationEventOnAddRemoveCode">
					<xsl:with-param name="MethodName" select="'Combine'"/>
				</xsl:call-template>
			</plx:onAdd>
			<plx:onRemove>
				<xsl:call-template name="GetINotifyPropertyChangedImplementationEventOnAddRemoveCode">
					<xsl:with-param name="MethodName" select="'Remove'"/>
				</xsl:call-template>
			</plx:onRemove>
		</plx:event>
		<plx:function visibility="private" overload="{not($RaiseEventsAsynchronously)}" name="OnPropertyChanged">
			<plx:param name="e" dataTypeName="PropertyChangedEventArgs"/>
			<plx:local name="eventHandler" dataTypeName="PropertyChangedEventHandler"/>
			<plx:branch>
				<plx:condition>
					<plx:binaryOperator type="identityInequality">
						<plx:left>
							<plx:cast type="exceptionCast" dataTypeName=".object">
								<plx:inlineStatement dataTypeName="PropertyChangedEventHandler">
									<plx:assign>
										<plx:left>
											<plx:nameRef type="local" name="eventHandler"/>
										</plx:left>
										<plx:right>
											<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangedEventHandler"/>
										</plx:right>
									</plx:assign>
								</plx:inlineStatement>
							</plx:cast>
						</plx:left>
						<plx:right>
							<plx:nullKeyword/>
						</plx:right>
					</plx:binaryOperator>
				</plx:condition>
				<xsl:variable name="commonCallCodeFragment">
					<plx:passParam>
						<plx:thisKeyword/>
					</plx:passParam>
					<plx:passParam>
						<plx:nameRef type="parameter" name="e"/>
					</plx:passParam>
				</xsl:variable>
				<xsl:variable name="commonCallCode" select="exsl:node-set($commonCallCodeFragment)/child::*"/>
				<xsl:choose>
					<xsl:when test="$RaiseEventsAsynchronously">
						<plx:callStatic name="InvokeEventHandlerAsync" dataTypeName="EventHandlerUtility" type="methodCall">
							<plx:passParam>
								<plx:nameRef type="local" name="eventHandler"/>
							</plx:passParam>
							<xsl:copy-of select="$commonCallCode"/>
						</plx:callStatic>
					</xsl:when>
					<xsl:otherwise>
						<plx:callInstance type="delegateCall" name=".implied">
							<plx:callObject>
								<plx:nameRef type="local" name="eventHandler"/>
							</plx:callObject>
							<xsl:copy-of select="$commonCallCode"/>
						</plx:callInstance>
					</xsl:otherwise>
				</xsl:choose>
			</plx:branch>
		</plx:function>
		<xsl:if test="not($RaiseEventsAsynchronously)">
			<plx:function visibility="private" overload="true" name="OnPropertyChanged">
				<plx:param name="e" dataTypeName="PropertyChangedEventArgs"/>
				<plx:local name="eventHandler" dataTypeName="PropertyChangedEventHandler"/>
				<plx:branch>
					<plx:condition>
						<plx:binaryOperator type="identityInequality">
							<plx:left>
								<plx:cast type="exceptionCast" dataTypeName=".object">
									<plx:inlineStatement dataTypeName="PropertyChangedEventHandler">
										<plx:assign>
											<plx:left>
												<plx:nameRef type="local" name="eventHandler"/>
											</plx:left>
											<plx:right>
												<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangedEventHandler"/>
											</plx:right>
										</plx:assign>
									</plx:inlineStatement>
								</plx:cast>
							</plx:left>
							<plx:right>
								<plx:nullKeyword/>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:callInstance type="delegateCall" name=".implied">
						<plx:callObject>
							<plx:nameRef type="local" name="eventHandler"/>
						</plx:callObject>
						<plx:passParam>
							<plx:thisKeyword/>
						</plx:passParam>
						<plx:passParam>
							<plx:nameRef type="parameter" name="e"/>
						</plx:passParam>
					</plx:callInstance>
				</plx:branch>
			</plx:function>
		</xsl:if>
	</xsl:template>

	<xsl:template name="GenerateINotifyPropertyChangingImplementation">
		<plx:field visibility="private" name="{$PrivateMemberPrefix}propertyChangingEventHandler" dataTypeName="PropertyChangingEventHandler"/>
		<plx:event visibility="privateInterfaceMember" name="PropertyChanging">
			<!-- Suppress the 'InterfaceMethodsShouldBeCallableByChildTypes' FxCop warning, since it is not applicable here. -->
			<!-- Child types call the property-specific notification methods, which in turn raise the INotifyPropertyChanging.PropertyChanging event. -->
			<xsl:call-template name="GenerateSuppressMessageAttribute">
				<xsl:with-param name="category" select="'Microsoft.Design'"/>
				<xsl:with-param name="checkId" select="'CA1033:InterfaceMethodsShouldBeCallableByChildTypes'"/>
			</xsl:call-template>
			<plx:interfaceMember memberName="PropertyChanging" dataTypeName="INotifyPropertyChanging"/>
			<plx:param name="sender" dataTypeName=".object"/>
			<plx:param name="e" dataTypeName="PropertyChangingEventArgs"/>
			<plx:explicitDelegateType dataTypeName="PropertyChangingEventHandler"/>
			<plx:onAdd>
				<xsl:call-template name="GetINotifyPropertyChangingImplementationEventOnAddRemoveCode">
					<xsl:with-param name="MethodName" select="'Combine'"/>
				</xsl:call-template>
			</plx:onAdd>
			<plx:onRemove>
				<xsl:call-template name="GetINotifyPropertyChangingImplementationEventOnAddRemoveCode">
					<xsl:with-param name="MethodName" select="'Remove'"/>
				</xsl:call-template>
			</plx:onRemove>
		</plx:event>
		<plx:function visibility="private" overload="{not($RaiseEventsAsynchronously)}" name="OnPropertyChanging">
			<plx:param name="e" dataTypeName="PropertyChangingEventArgs"/>
			<plx:local name="eventHandler" dataTypeName="PropertyChangingEventHandler"/>
			<plx:branch>
				<plx:condition>
					<plx:binaryOperator type="identityInequality">
						<plx:left>
							<plx:cast type="exceptionCast" dataTypeName=".object">
								<plx:inlineStatement dataTypeName="PropertyChangingEventHandler">
									<plx:assign>
										<plx:left>
											<plx:nameRef type="local" name="eventHandler"/>
										</plx:left>
										<plx:right>
											<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangingEventHandler"/>
										</plx:right>
									</plx:assign>
								</plx:inlineStatement>
							</plx:cast>
						</plx:left>
						<plx:right>
							<plx:nullKeyword/>
						</plx:right>
					</plx:binaryOperator>
				</plx:condition>
				<xsl:variable name="commonCallCodeFragment">
					<plx:passParam>
						<plx:thisKeyword/>
					</plx:passParam>
					<plx:passParam>
						<plx:nameRef type="parameter" name="e"/>
					</plx:passParam>
				</xsl:variable>
				<xsl:variable name="commonCallCode" select="exsl:node-set($commonCallCodeFragment)/child::*"/>
				<xsl:choose>
					<xsl:when test="$RaiseEventsAsynchronously">
						<plx:callStatic name="InvokeEventHandlerAsync" dataTypeName="EventHandlerUtility" type="methodCall">
							<plx:passParam>
								<plx:nameRef type="local" name="eventHandler"/>
							</plx:passParam>
							<xsl:copy-of select="$commonCallCode"/>
						</plx:callStatic>
					</xsl:when>
					<xsl:otherwise>
						<plx:callInstance type="delegateCall" name=".implied">
							<plx:callObject>
								<plx:nameRef type="local" name="eventHandler"/>
							</plx:callObject>
							<xsl:copy-of select="$commonCallCode"/>
						</plx:callInstance>
					</xsl:otherwise>
				</xsl:choose>
			</plx:branch>
		</plx:function>
		<xsl:if test="not($RaiseEventsAsynchronously)">
			<plx:function visibility="private" overload="true" name="OnPropertyChanging">
				<plx:param name="e" dataTypeName="PropertyChangingEventArgs"/>
				<plx:local name="eventHandler" dataTypeName="PropertyChangingEventHandler"/>
				<plx:branch>
					<plx:condition>
						<plx:binaryOperator type="identityInequality">
							<plx:left>
								<plx:cast type="exceptionCast" dataTypeName=".object">
									<plx:inlineStatement dataTypeName="PropertyChangingEventHandler">
										<plx:assign>
											<plx:left>
												<plx:nameRef type="local" name="eventHandler"/>
											</plx:left>
											<plx:right>
												<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangingEventHandler"/>
											</plx:right>
										</plx:assign>
									</plx:inlineStatement>
								</plx:cast>
							</plx:left>
							<plx:right>
								<plx:nullKeyword/>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:callInstance type="delegateCall" name=".implied">
						<plx:callObject>
							<plx:nameRef type="local" name="eventHandler"/>
						</plx:callObject>
						<plx:passParam>
							<plx:thisKeyword/>
						</plx:passParam>
						<plx:passParam>
							<plx:nameRef type="parameter" name="e"/>
						</plx:passParam>
					</plx:callInstance>
				</plx:branch>
			</plx:function>
		</xsl:if>
	</xsl:template>

	<xsl:template name="GenerateSuppressMessageAttribute">
		<xsl:param name="category"/>
		<xsl:param name="checkId"/>
		<xsl:param name="justification"/>
		<xsl:param name="messageId"/>
		<xsl:param name="scope"/>
		<xsl:param name="target"/>
		<xsl:if test="$GenerateCodeAnalysisAttributes">
			<plx:attribute dataTypeName="SuppressMessageAttribute">
				<plx:passParam>
					<plx:string>
						<xsl:value-of select="$category"/>
					</plx:string>
				</plx:passParam>
				<plx:passParam>
					<plx:string>
						<xsl:value-of select="$checkId"/>
					</plx:string>
				</plx:passParam>
				<xsl:if test="$justification">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef type="namedParameter" name="Justification"/>
							</plx:left>
							<plx:right>
								<plx:string>
									<xsl:value-of select="$justification"/>
								</plx:string>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</xsl:if>
				<xsl:if test="$messageId">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef type="namedParameter" name="MessageId"/>
							</plx:left>
							<plx:right>
								<plx:string>
									<xsl:value-of select="$messageId"/>
								</plx:string>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</xsl:if>
				<xsl:if test="$scope">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef type="namedParameter" name="Scope"/>
							</plx:left>
							<plx:right>
								<plx:string>
									<xsl:value-of select="$scope"/>
								</plx:string>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</xsl:if>
				<xsl:if test="$target">
					<plx:passParam>
						<plx:binaryOperator type="assignNamed">
							<plx:left>
								<plx:nameRef type="namedParameter" name="Target"/>
							</plx:left>
							<plx:right>
								<plx:string>
									<xsl:value-of select="$target"/>
								</plx:string>
							</plx:right>
						</plx:binaryOperator>
					</plx:passParam>
				</xsl:if>
			</plx:attribute>
		</xsl:if>
	</xsl:template>

	<xsl:template name="GetINotifyPropertyChangingImplementationEventOnAddRemoveCode">
		<xsl:param name="MethodName"/>
		<plx:branch>
			<plx:condition>
				<plx:binaryOperator type="identityInequality">
					<plx:left>
						<plx:cast type="exceptionCast" dataTypeName=".object">
							<plx:valueKeyword/>
						</plx:cast>
					</plx:left>
					<plx:right>
						<plx:nullKeyword/>
					</plx:right>
				</plx:binaryOperator>
			</plx:condition>
			<xsl:choose>
				<xsl:when test="$SynchronizeEventAddRemove">
					<plx:local name="currentHandler" dataTypeName="PropertyChangingEventHandler"/>
					<plx:loop checkCondition="before">
						<plx:condition>
							<plx:binaryOperator type="identityInequality">
								<plx:left>
									<plx:cast type="exceptionCast" dataTypeName=".object">
										<plx:callStatic type="methodCall" name="CompareExchange" dataTypeName="Interlocked">
											<plx:passMemberTypeParam dataTypeName="PropertyChangingEventHandler"/>
											<plx:passParam type="inOut">
												<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangingEventHandler"/>
											</plx:passParam>
											<plx:passParam>
												<plx:cast type="exceptionCast" dataTypeName="PropertyChangingEventHandler">
													<!-- PLIX_TODO: Once the PLiX formatters support keyword filtering, remove the dataTypeQualifier attribute from the next line. -->
													<plx:callStatic type="methodCall" name="{$MethodName}" dataTypeName="Delegate" dataTypeQualifier="System">
														<plx:passParam>
															<plx:inlineStatement dataTypeName="PropertyChangingEventHandler">
																<plx:assign>
																	<plx:left>
																		<plx:nameRef type="local" name="currentHandler"/>
																	</plx:left>
																	<plx:right>
																		<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangingEventHandler"/>
																	</plx:right>
																</plx:assign>
															</plx:inlineStatement>
														</plx:passParam>
														<plx:passParam>
															<plx:valueKeyword/>
														</plx:passParam>
													</plx:callStatic>
												</plx:cast>
											</plx:passParam>
											<plx:passParam>
												<plx:nameRef type="local" name="currentHandler"/>
											</plx:passParam>
										</plx:callStatic>
									</plx:cast>
								</plx:left>
								<plx:right>
									<plx:cast type="exceptionCast" dataTypeName=".object">
										<plx:nameRef type="local" name="currentHandler"/>
									</plx:cast>
								</plx:right>
							</plx:binaryOperator>
						</plx:condition>
					</plx:loop>
				</xsl:when>
				<xsl:otherwise>
					<plx:assign>
						<plx:left>
							<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangingEventHandler"/>
						</plx:left>
						<plx:right>
							<plx:cast type="exceptionCast" dataTypeName="PropertyChangingEventHandler">
								<!-- PLIX_TODO: Once the PLiX formatters support keyword filtering, remove the dataTypeQualifier attribute from the next line. -->
								<plx:callStatic type="methodCall" name="Combine" dataTypeName="Delegate" dataTypeQualifier="System">
									<plx:passParam>
										<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangingEventHandler"/>
									</plx:passParam>
									<plx:passParam>
										<plx:valueKeyword/>
									</plx:passParam>
								</plx:callStatic>
							</plx:cast>
						</plx:right>
					</plx:assign>
				</xsl:otherwise>
			</xsl:choose>
		</plx:branch>
	</xsl:template>

	<xsl:template name="GetINotifyPropertyChangedImplementationEventOnAddRemoveCode">
		<xsl:param name="MethodName"/>
		<plx:branch>
			<plx:condition>
				<plx:binaryOperator type="identityInequality">
					<plx:left>
						<plx:cast type="exceptionCast" dataTypeName=".object">
							<plx:valueKeyword/>
						</plx:cast>
					</plx:left>
					<plx:right>
						<plx:nullKeyword/>
					</plx:right>
				</plx:binaryOperator>
			</plx:condition>
			<xsl:choose>
				<xsl:when test="$SynchronizeEventAddRemove">
					<plx:local name="currentHandler" dataTypeName="PropertyChangedEventHandler"/>
					<plx:loop checkCondition="before">
						<plx:condition>
							<plx:binaryOperator type="identityInequality">
								<plx:left>
									<plx:cast type="exceptionCast" dataTypeName=".object">
										<plx:callStatic type="methodCall" name="CompareExchange" dataTypeName="Interlocked">
											<plx:passMemberTypeParam dataTypeName="PropertyChangedEventHandler"/>
											<plx:passParam type="inOut">
												<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangedEventHandler"/>
											</plx:passParam>
											<plx:passParam>
												<plx:cast type="exceptionCast" dataTypeName="PropertyChangedEventHandler">
													<!-- PLIX_TODO: Once the PLiX formatters support keyword filtering, remove the dataTypeQualifier attribute from the next line. -->
													<plx:callStatic type="methodCall" name="{$MethodName}" dataTypeName="Delegate" dataTypeQualifier="System">
														<plx:passParam>
															<plx:inlineStatement dataTypeName="PropertyChangedEventHandler">
																<plx:assign>
																	<plx:left>
																		<plx:nameRef type="local" name="currentHandler"/>
																	</plx:left>
																	<plx:right>
																		<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangedEventHandler"/>
																	</plx:right>
																</plx:assign>
															</plx:inlineStatement>
														</plx:passParam>
														<plx:passParam>
															<plx:valueKeyword/>
														</plx:passParam>
													</plx:callStatic>
												</plx:cast>
											</plx:passParam>
											<plx:passParam>
												<plx:nameRef type="local" name="currentHandler"/>
											</plx:passParam>
										</plx:callStatic>
									</plx:cast>
								</plx:left>
								<plx:right>
									<plx:cast type="exceptionCast" dataTypeName=".object">
										<plx:nameRef type="local" name="currentHandler"/>
									</plx:cast>
								</plx:right>
							</plx:binaryOperator>
						</plx:condition>
					</plx:loop>
				</xsl:when>
				<xsl:otherwise>
					<plx:assign>
						<plx:left>
							<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangedEventHandler"/>
						</plx:left>
						<plx:right>
							<plx:cast type="exceptionCast" dataTypeName="PropertyChangedEventHandler">
								<!-- PLIX_TODO: Once the PLiX formatters support keyword filtering, remove the dataTypeQualifier attribute from the next line. -->
								<plx:callStatic type="methodCall" name="Combine" dataTypeName="Delegate" dataTypeQualifier="System">
									<plx:passParam>
										<plx:callThis accessor="this" type="field" name="{$PrivateMemberPrefix}propertyChangedEventHandler"/>
									</plx:passParam>
									<plx:passParam>
										<plx:valueKeyword/>
									</plx:passParam>
								</plx:callStatic>
							</plx:cast>
						</plx:right>
					</plx:assign>
				</xsl:otherwise>
			</xsl:choose>
		</plx:branch>
	</xsl:template>

	<xsl:template name="GenerateGlobalSupportClasses">
		<plx:class visibility="public" modifier="static" name="EventHandlerUtility">
			<plx:attribute dataTypeName="HostProtectionAttribute" dataTypeQualifier="System.Security.Permissions">
				<plx:passParam>
					<plx:callStatic type="field" name="LinkDemand" dataTypeName="SecurityAction" dataTypeQualifier="System.Security.Permissions"/>
				</plx:passParam>
				<plx:passParam>
					<plx:binaryOperator type="assignNamed">
						<plx:left>
							<plx:nameRef type="namedParameter" name="SharedState"/>
						</plx:left>
						<plx:right>
							<plx:trueKeyword/>
						</plx:right>
					</plx:binaryOperator>
				</plx:passParam>
			</plx:attribute>

			<plx:function visibility="public" modifier="static" name="InvokeEventHandlerAsync">
				<plx:param name="eventHandler" dataTypeName="PropertyChangedEventHandler"/>
				<plx:param name="sender" dataTypeName=".object"/>
				<plx:param name="e" dataTypeName="PropertyChangedEventArgs"/>
				<plx:branch>
					<plx:condition>
						<plx:binaryOperator type="identityEquality">
							<plx:left>
								<plx:cast type="exceptionCast" dataTypeName=".object">
									<plx:nameRef type="parameter" name="eventHandler"/>
								</plx:cast>
							</plx:left>
							<plx:right>
								<plx:nullKeyword/>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:throw>
						<plx:callNew dataTypeName="ArgumentNullException">
							<plx:passParam>
								<plx:string data="eventHandler"/>
							</plx:passParam>
						</plx:callNew>
					</plx:throw>
				</plx:branch>
				<!-- PLIX_TODO: Once the PLiX formatters support keyword filtering, remove the dataTypeQualifier attribute from the next line. -->
				<plx:local name="invocationList" dataTypeName="Delegate" dataTypeQualifier="System" dataTypeIsSimpleArray="true">
					<plx:initialize>
						<plx:callInstance type="methodCall" name="GetInvocationList">
							<plx:callObject>
								<plx:nameRef type="parameter" name="eventHandler"/>
							</plx:callObject>
						</plx:callInstance>
					</plx:initialize>
				</plx:local>
				<plx:loop checkCondition="before">
					<plx:initializeLoop>
						<plx:local name="i" dataTypeName=".i4">
							<plx:initialize>
								<plx:value type="i4" data="0"/>
							</plx:initialize>
						</plx:local>
					</plx:initializeLoop>
					<plx:condition>
						<plx:binaryOperator type="lessThan">
							<plx:left>
								<plx:nameRef type="local" name="i"/>
							</plx:left>
							<plx:right>
								<plx:callInstance type="property" name="Length">
									<plx:callObject>
										<plx:nameRef type="local" name="invocationList"/>
									</plx:callObject>
								</plx:callInstance>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:beforeLoop>
						<plx:increment type="post">
							<plx:nameRef type="local" name="i"/>
						</plx:increment>
					</plx:beforeLoop>
					<plx:local name="currentEventHandler" dataTypeName="PropertyChangedEventHandler">
						<plx:initialize>
							<plx:cast type="exceptionCast" dataTypeName="PropertyChangedEventHandler">
								<plx:callInstance type="arrayIndexer" name=".implied">
									<plx:callObject>
										<plx:nameRef type="local" name="invocationList"/>
									</plx:callObject>
									<plx:passParam>
										<plx:nameRef type="local" name="i"/>
									</plx:passParam>
								</plx:callInstance>
							</plx:cast>
						</plx:initialize>
					</plx:local>
					<plx:callInstance type="methodCall" name="BeginInvoke">
						<plx:callObject>
							<plx:nameRef type="local" name="currentEventHandler"/>
						</plx:callObject>
						<plx:passParam>
							<plx:nameRef type="parameter" name="sender"/>
						</plx:passParam>
						<plx:passParam>
							<plx:nameRef type="parameter" name="e"/>
						</plx:passParam>
						<plx:passParam>
							<plx:callNew dataTypeName="AsyncCallback">
								<plx:passParam>
									<plx:callInstance type="methodReference" name="EndInvoke">
										<plx:callObject>
											<plx:nameRef type="local" name="currentEventHandler"/>
										</plx:callObject>
									</plx:callInstance>
								</plx:passParam>
							</plx:callNew>
						</plx:passParam>
						<plx:passParam>
							<plx:nullKeyword/>
						</plx:passParam>
					</plx:callInstance>
				</plx:loop>
			</plx:function>
			<plx:function visibility="public" modifier="static" name="InvokeEventHandlerAsync">
				<plx:param name="eventHandler" dataTypeName="PropertyChangingEventHandler"/>
				<plx:param name="sender" dataTypeName=".object"/>
				<plx:param name="e" dataTypeName="PropertyChangingEventArgs"/>
				<plx:branch>
					<plx:condition>
						<plx:binaryOperator type="identityEquality">
							<plx:left>
								<plx:cast type="exceptionCast" dataTypeName=".object">
									<plx:nameRef type="parameter" name="eventHandler"/>
								</plx:cast>
							</plx:left>
							<plx:right>
								<plx:nullKeyword/>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:throw>
						<plx:callNew dataTypeName="ArgumentNullException">
							<plx:passParam>
								<plx:string data="eventHandler"/>
							</plx:passParam>
						</plx:callNew>
					</plx:throw>
				</plx:branch>
				<!-- PLIX_TODO: Once the PLiX formatters support keyword filtering, remove the dataTypeQualifier attribute from the next line. -->
				<plx:local name="invocationList" dataTypeName="Delegate" dataTypeQualifier="System" dataTypeIsSimpleArray="true">
					<plx:initialize>
						<plx:callInstance type="methodCall" name="GetInvocationList">
							<plx:callObject>
								<plx:nameRef type="parameter" name="eventHandler"/>
							</plx:callObject>
						</plx:callInstance>
					</plx:initialize>
				</plx:local>
				<plx:loop checkCondition="before">
					<plx:initializeLoop>
						<plx:local name="i" dataTypeName=".i4">
							<plx:initialize>
								<plx:value type="i4" data="0"/>
							</plx:initialize>
						</plx:local>
					</plx:initializeLoop>
					<plx:condition>
						<plx:binaryOperator type="lessThan">
							<plx:left>
								<plx:nameRef type="local" name="i"/>
							</plx:left>
							<plx:right>
								<plx:callInstance type="property" name="Length">
									<plx:callObject>
										<plx:nameRef type="local" name="invocationList"/>
									</plx:callObject>
								</plx:callInstance>
							</plx:right>
						</plx:binaryOperator>
					</plx:condition>
					<plx:beforeLoop>
						<plx:increment type="post">
							<plx:nameRef type="local" name="i"/>
						</plx:increment>
					</plx:beforeLoop>
					<plx:local name="currentEventHandler" dataTypeName="PropertyChangingEventHandler">
						<plx:initialize>
							<plx:cast type="exceptionCast" dataTypeName="PropertyChangingEventHandler">
								<plx:callInstance type="arrayIndexer" name=".implied">
									<plx:callObject>
										<plx:nameRef type="local" name="invocationList"/>
									</plx:callObject>
									<plx:passParam>
										<plx:nameRef type="local" name="i"/>
									</plx:passParam>
								</plx:callInstance>
							</plx:cast>
						</plx:initialize>
					</plx:local>
					<plx:callInstance type="methodCall" name="BeginInvoke">
						<plx:callObject>
							<plx:nameRef type="local" name="currentEventHandler"/>
						</plx:callObject>
						<plx:passParam>
							<plx:nameRef type="parameter" name="sender"/>
						</plx:passParam>
						<plx:passParam>
							<plx:nameRef type="parameter" name="e"/>
						</plx:passParam>
						<plx:passParam>
							<plx:callNew dataTypeName="AsyncCallback">
								<plx:passParam>
									<plx:callInstance type="methodReference" name="EndInvoke">
										<plx:callObject>
											<plx:nameRef type="local" name="currentEventHandler"/>
										</plx:callObject>
									</plx:callInstance>
								</plx:passParam>
							</plx:callNew>
						</plx:passParam>
						<plx:passParam>
							<plx:nullKeyword/>
						</plx:passParam>
					</plx:callInstance>
				</plx:loop>
			</plx:function>
		</plx:class>
	</xsl:template>

	<xsl:template name="GetDbTypeFromDcilPredefinedDataType">
		<xsl:param name="predefinedDataType"/>
		<xsl:param name="column"/>
		<xsl:variable name="predefinedDataTypeName" select="$predefinedDataType/@name"/>
		<xsl:choose>
			<xsl:when test="$predefinedDataTypeName = 'CHARACTER'">
				<xsl:value-of select="'NChar'"/>
				<xsl:text>(</xsl:text>
				<xsl:choose>
					<xsl:when test="string($predefinedDataType/@length)">
						<xsl:value-of select="$predefinedDataType/@length"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="4000"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>)</xsl:text>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'CHARACTER VARYING'">
				<xsl:value-of select="'NVarChar'"/>
				<xsl:text>(</xsl:text>
				<xsl:choose>
					<xsl:when test="string($predefinedDataType/@length)">
						<xsl:value-of select="$predefinedDataType/@length"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'Max'"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:text>)</xsl:text>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'CHARACTER LARGE OBJECT'">
				<xsl:value-of select="'NVarChar'"/>
				<xsl:text>(</xsl:text>
				<xsl:choose>
					<xsl:when test="string($predefinedDataType/@length)">
						<xsl:value-of select="$predefinedDataType/@length"/>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'Max'"/>
					</xsl:otherwise>
				</xsl:choose>
				<xsl:value-of select="$predefinedDataType/@length"/>
				<xsl:text>)</xsl:text>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BINARY LARGE OBJECT'">
				<xsl:value-of select="'VarBinary'"/>
				<xsl:text>(</xsl:text>
				<xsl:value-of select="$predefinedDataType/@length"/>
				<xsl:text>)</xsl:text>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BINARY VARYING'">
				<xsl:value-of select="'VarBinary'"/>
				<xsl:if test="string($predefinedDataTypeName/@length)">
					<xsl:text>(</xsl:text>
					<xsl:value-of select="$predefinedDataType/@length"/>
					<xsl:text>)</xsl:text>
				</xsl:if>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BINARY'">
				<xsl:value-of select="'Binary'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'NUMERIC'">
				<xsl:value-of select="'Numeric'"/>
				<xsl:if test="$predefinedDataType/@precision">
					<xsl:text>(</xsl:text>
					<xsl:value-of select="$predefinedDataType/@precision"/>
					<xsl:if test="$predefinedDataType/@scale">
						<xsl:text>, </xsl:text>
						<xsl:value-of select="$predefinedDataType/@scale"/>
					</xsl:if>
					<xsl:text>)</xsl:text>
				</xsl:if>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DECIMAL'">
				<xsl:value-of select="'Decimal'"/>
				<xsl:if test="$predefinedDataType/@precision">
					<xsl:text>(</xsl:text>
					<xsl:value-of select="$predefinedDataType/@precision"/>
					<xsl:if test="$predefinedDataType/@scale">
						<xsl:text>, </xsl:text>
						<xsl:value-of select="$predefinedDataType/@scale"/>
					</xsl:if>
					<xsl:text>)</xsl:text>
				</xsl:if>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'SMALLINT'">
				<xsl:value-of select="'SmallInt'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TINYINT'">
				<xsl:value-of select="'TinyInt'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'INTEGER'">
				<xsl:value-of select="'Int'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BIGINT'">
				<xsl:value-of select="'BigInt'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'FLOAT'">
				<xsl:value-of select="'Float'"/>
				<xsl:if test="string($predefinedDataType/@precision)">
					<xsl:text>(</xsl:text>
					<xsl:value-of select="$predefinedDataType/@precision"/>
					<xsl:text>)</xsl:text>
				</xsl:if>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'REAL'">
				<xsl:value-of select="'Real'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DOUBLE PRECISION'">
				<xsl:value-of select="'Float(53)'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BOOLEAN'">
				<xsl:value-of select="'Bit'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DATE'">
				<xsl:value-of select="'DateTime'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TIME'">
				<xsl:value-of select="'DateTime'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TIMESTAMP'">
				<xsl:value-of select="'DateTime'"/>
				<!--
				This one is wierd in the default mapping in SQL Server where they use a different meaning for Timestamp.
				[Column(Storage="_Region_code", AutoSync=AutoSync.Always, DbType="rowversion", IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
				public System.Data.Linq.Binary Region_code
				-->
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'INTERVAL'">
				<xsl:value-of select="''"/>
			</xsl:when>
			<!--
			<xsl:when test="$predefinedDataTypeName = 'DAY'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DAY TO HOUR'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DAY TO MINUTE'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DAY TO SECOND'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'HOUR'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'HOUR TO MINUTE'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'HOUR TO SECOND'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'SECOND'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'YEAR'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'YEAR TO MONTH'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'MONTH'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TIMEZONE_HOUR'">
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TIMEZONE_MINUTE'">
			</xsl:when>
			-->
		</xsl:choose>
		<xsl:if test="$column/@isNullable = 'false' or $column/@isNullable = 0">
			<xsl:text> NOT NULL</xsl:text>
			<xsl:if test="$predefinedDataTypeName = 'BIGINT' or $predefinedDataTypeName = 'INTEGER'">
				<xsl:if test="$column/@isIdentity = 'true' or $column/@isIdentity = 1">
					<xsl:text> IDENTITY</xsl:text>
				</xsl:if>
			</xsl:if>
		</xsl:if>
	</xsl:template>

	<xsl:template name="GetDotNetTypeFromDcilPredefinedDataType">
		<xsl:param name="predefinedDataType"/>
		<xsl:param name="column"/>
		<xsl:variable name="predefinedDataTypeName" select="$predefinedDataType/@name"/>
		<xsl:choose>
			<xsl:when test="$predefinedDataTypeName = 'CHARACTER'">
				<xsl:value-of select="'String'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'CHARACTER VARYING'">
				<xsl:value-of select="'String'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'CHARACTER LARGE OBJECT'">
				<xsl:value-of select="'String'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BINARY'">
				<xsl:value-of select="'Byte[]'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BINARY VARYING'">
				<xsl:value-of select="'Byte[]'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BINARY LARGE OBJECT'">
				<xsl:value-of select="'Byte[]'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'NUMERIC'">
				<xsl:value-of select="'Decimal'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DECIMAL'">
				<xsl:value-of select="'Decimal'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TINYINT'">
				<xsl:value-of select="'Byte'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'SMALLINT'">
				<xsl:value-of select="'Int16'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'INTEGER'">
				<xsl:value-of select="'Int32'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BIGINT'">
				<xsl:value-of select="'Int64'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'FLOAT'">
				<xsl:choose>
					<xsl:when test="string($predefinedDataTypeName/@percision)">
						<xsl:choose>
							<xsl:when test="$predefinedDataTypeName/@percision &lt;= 24">
								<xsl:value-of select="'Single'"/>
							</xsl:when>
							<xsl:otherwise>
								<xsl:value-of select="'Double'"/>
							</xsl:otherwise>
						</xsl:choose>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="'Double'"/>
					</xsl:otherwise>
				</xsl:choose>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'REAL'">
				<xsl:value-of select="'Single'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DOUBLE PRECISION'">
				<xsl:value-of select="'Double'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'BOOLEAN'">
				<xsl:value-of select="'Boolean'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'DATE'">
				<xsl:value-of select="'DateTime'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TIME'">
				<xsl:value-of select="'DateTime'"/>
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'TIMESTAMP'">
				<xsl:value-of select="'DateTime'"/>
				<!--
				This one is wierd.
				[Column(Storage="_Region_code", AutoSync=AutoSync.Always, DbType="rowversion", IsDbGenerated=true, IsVersion=true, UpdateCheck=UpdateCheck.Never)]
				public System.Data.Linq.Binary Region_code
				-->
			</xsl:when>
			<xsl:when test="$predefinedDataTypeName = 'INTERVAL'">
				<xsl:value-of select="'TimeSpan'"/>
			</xsl:when>
		</xsl:choose>
	</xsl:template>
	
	<!--<xsl:template name="GenerateToString">
		<xsl:param name="ClassName"/>
		<xsl:param name="Properties"/>
		<xsl:variable name="nonCollectionProperties" select="$Properties[not(@isCollection='true')]"/>
		<plx:function visibility="public" modifier="override" overload="true" name="ToString">
			<plx:returns dataTypeName=".string"/>
			<plx:return>
				<plx:callThis accessor="this" type="methodCall" name="ToString">
					<plx:passParam>
						<plx:nullKeyword/>
					</plx:passParam>
				</plx:callThis>
			</plx:return>
		</plx:function>
		<plx:function visibility="public" modifier="virtual" overload="true" name="ToString">
			<plx:param name="provider" dataTypeName="IFormatProvider"/>
			<plx:returns dataTypeName=".string"/>
			<plx:return>
				<plx:callStatic name="Format" dataTypeName=".string">
					<plx:passParam>
						<plx:nameRef type="parameter" name="provider"/>
					</plx:passParam>
					<plx:passParam>
						<plx:string>
							<xsl:value-of select="concat($ClassName,'{0}{{{0}{1}')"/>
							<xsl:for-each select="$nonCollectionProperties">
								<xsl:value-of select="concat(@name,' = ')"/>
								<xsl:if test="not(@isCustomType='true')">
									<xsl:value-of select="'&quot;'"/>
								</xsl:if>
								<xsl:value-of select="concat('{',position()+1,'}')"/>
								<xsl:if test="not(@isCustomType='true')">
									<xsl:value-of select="'&quot;'"/>
								</xsl:if>
								<xsl:if test="not(position()=last())">
									<xsl:value-of select="',{0}{1}'"/>
								</xsl:if>
							</xsl:for-each>
							<xsl:value-of select="'{0}}}'"/>
						</plx:string>
					</plx:passParam>
					<plx:passParam>
						<plx:callStatic type="field" name="NewLine" dataTypeName="Environment"/>
					</plx:passParam>
					<plx:passParam>
						<plx:string>
							<xsl:text disable-output-escaping="yes">&amp;#x09;</xsl:text>
						</plx:string>
					</plx:passParam>
					<xsl:for-each select="$nonCollectionProperties">
						<plx:passParam>
							<xsl:choose>
								<xsl:when test="@isCustomType='true'">
									<plx:string>TODO: Recursively call ToString for customTypes...</plx:string>
								</xsl:when>
								<xsl:otherwise>
									<plx:callThis accessor="this" type="property" name="{@name}"/>
								</xsl:otherwise>
							</xsl:choose>
						</plx:passParam>
					</xsl:for-each>
				</plx:callStatic>
			</plx:return>
		</plx:function>
	</xsl:template>

	<xsl:template match="oial:conceptType" mode="GetInformationTypesForPreferredIdentifier">
		-->
	

</xsl:stylesheet>