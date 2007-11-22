﻿#region Common Public License Copyright Notice
/**************************************************************************\
* Neumont Object-Role Modeling Architect for Visual Studio                 *
*                                                                          *
* Copyright © Neumont University. All rights reserved.                     *
*                                                                          *
* The use and distribution terms for this software are covered by the      *
* Common Public License 1.0 (http://opensource.org/licenses/cpl) which     *
* can be found in the file CPL.txt at the root of this distribution.       *
* By using this software in any fashion, you are agreeing to be bound by   *
* the terms of this license.                                               *
*                                                                          *
* You must not remove this notice, or any other, from this software.       *
\**************************************************************************/
#endregion
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DslModeling = global::Microsoft.VisualStudio.Modeling;
using DslDesign = global::Microsoft.VisualStudio.Modeling.Design;
namespace Neumont.Tools.ORMToORMAbstractionBridge
{
	/// <summary>
	/// DomainModel ORMToORMAbstractionBridgeDomainModel
	/// Bridge ORM and attribute-centric ORM Abstraction Model
	/// </summary>
	[DslModeling::ExtendsDomainModel("3EAE649F-E654-4D04-8289-C25D2C0322D8"/*Neumont.Tools.ORM.ObjectModel.ORMCoreDomainModel*/)]
	[DslModeling::ExtendsDomainModel("F7BC82F4-83D1-408C-BA42-607E90B23BEA"/*Neumont.Tools.ORMAbstraction.AbstractionDomainModel*/)]
	[DslDesign::DisplayNameResource("Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel.DisplayName", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
	[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DomainObjectId("1f394f03-8a41-48bc-bded-2268e131b4a3")]
	public partial class ORMToORMAbstractionBridgeDomainModel : DslModeling::DomainModel
	{
		#region Constructor, domain model Id
	
		/// <summary>
		/// ORMToORMAbstractionBridgeDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new global::System.Guid(0x1f394f03, 0x8a41, 0x48bc, 0xbd, 0xed, 0x22, 0x68, 0xe1, 0x31, 0xb4, 0xa3);
	
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public ORMToORMAbstractionBridgeDomainModel(DslModeling::Store store)
			: base(store, DomainModelId)
		{
		}
		
		#endregion
		#region Domain model reflection
			
		/// <summary>
		/// Gets the list of generated domain model types (classes, rules, relationships).
		/// </summary>
		/// <returns>List of types.</returns>
		protected sealed override global::System.Type[] GetGeneratedDomainModelTypes()
		{
			return new global::System.Type[]
			{
				typeof(FactTypeMapsTowardsRole),
				typeof(AbstractionModelIsForORMModel),
				typeof(ConceptTypeIsForObjectType),
				typeof(ConceptTypeChildHasPathFactType),
				typeof(InformationTypeFormatIsForValueType),
				typeof(UniquenessIsForUniquenessConstraint),
				typeof(ExcludedORMModelElement),
			};
		}
		/// <summary>
		/// Gets the list of generated domain properties.
		/// </summary>
		/// <returns>List of property data.</returns>
		protected sealed override DomainMemberInfo[] GetGeneratedDomainProperties()
		{
			return new DomainMemberInfo[]
			{
				new DomainMemberInfo(typeof(FactTypeMapsTowardsRole), "Depth", FactTypeMapsTowardsRole.DepthDomainPropertyId, typeof(FactTypeMapsTowardsRole.DepthPropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeMapsTowardsRole), "UniquenessPattern", FactTypeMapsTowardsRole.UniquenessPatternDomainPropertyId, typeof(FactTypeMapsTowardsRole.UniquenessPatternPropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeMapsTowardsRole), "MandatoryPattern", FactTypeMapsTowardsRole.MandatoryPatternDomainPropertyId, typeof(FactTypeMapsTowardsRole.MandatoryPatternPropertyHandler)),
			};
		}
		/// <summary>
		/// Gets the list of generated domain roles.
		/// </summary>
		/// <returns>List of role data.</returns>
		protected sealed override DomainRolePlayerInfo[] GetGeneratedDomainRoles()
		{
			return new DomainRolePlayerInfo[]
			{
				new DomainRolePlayerInfo(typeof(FactTypeMapsTowardsRole), "FactType", FactTypeMapsTowardsRole.FactTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(FactTypeMapsTowardsRole), "TowardsRole", FactTypeMapsTowardsRole.TowardsRoleDomainRoleId),
				new DomainRolePlayerInfo(typeof(AbstractionModelIsForORMModel), "AbstractionModel", AbstractionModelIsForORMModel.AbstractionModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(AbstractionModelIsForORMModel), "ORMModel", AbstractionModelIsForORMModel.ORMModelDomainRoleId),
				new DomainRolePlayerInfo(typeof(ConceptTypeIsForObjectType), "ConceptType", ConceptTypeIsForObjectType.ConceptTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(ConceptTypeIsForObjectType), "ObjectType", ConceptTypeIsForObjectType.ObjectTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(ConceptTypeChildHasPathFactType), "ConceptTypeChild", ConceptTypeChildHasPathFactType.ConceptTypeChildDomainRoleId),
				new DomainRolePlayerInfo(typeof(ConceptTypeChildHasPathFactType), "PathFactType", ConceptTypeChildHasPathFactType.PathFactTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(InformationTypeFormatIsForValueType), "InformationTypeFormat", InformationTypeFormatIsForValueType.InformationTypeFormatDomainRoleId),
				new DomainRolePlayerInfo(typeof(InformationTypeFormatIsForValueType), "ValueType", InformationTypeFormatIsForValueType.ValueTypeDomainRoleId),
				new DomainRolePlayerInfo(typeof(UniquenessIsForUniquenessConstraint), "Uniqueness", UniquenessIsForUniquenessConstraint.UniquenessDomainRoleId),
				new DomainRolePlayerInfo(typeof(UniquenessIsForUniquenessConstraint), "UniquenessConstraint", UniquenessIsForUniquenessConstraint.UniquenessConstraintDomainRoleId),
				new DomainRolePlayerInfo(typeof(ExcludedORMModelElement), "ExcludedElement", ExcludedORMModelElement.ExcludedElementDomainRoleId),
				new DomainRolePlayerInfo(typeof(ExcludedORMModelElement), "AbstractionModel", ExcludedORMModelElement.AbstractionModelDomainRoleId),
			};
		}
		#endregion
		#region Factory methods
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementMap;
	
		/// <summary>
		/// Creates an element of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementType">Element type which belongs to this domain model.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ModelElement CreateElement(DslModeling::Partition partition, global::System.Type elementType, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementType == null) throw new global::System.ArgumentNullException("elementType");
	
			if (createElementMap == null)
			{
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(0);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				throw new global::System.ArgumentException("elementType is not recognized as a type of domain class which belongs to this domain model.");
			}
			switch (index)
			{
				default: return null;
			}
		}
	
		private static global::System.Collections.Generic.Dictionary<global::System.Type, int> createElementLinkMap;
	
		/// <summary>
		/// Creates an element link of specified type.
		/// </summary>
		/// <param name="partition">Partition where element is to be created.</param>
		/// <param name="elementLinkType">Element link type which belongs to this domain model.</param>
		/// <param name="roleAssignments">List of relationship role assignments for the new link.</param>
		/// <param name="propertyAssignments">New element property assignments.</param>
		/// <returns>Created element link.</returns>
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
		public sealed override DslModeling::ElementLink CreateElementLink(DslModeling::Partition partition, global::System.Type elementLinkType, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
		{
			if (elementLinkType == null) throw new global::System.ArgumentNullException("elementType");
			if (roleAssignments == null) throw new global::System.ArgumentNullException("roleAssignments");
	
			if (createElementLinkMap == null)
			{
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(7);
				createElementLinkMap.Add(typeof(FactTypeMapsTowardsRole), 0);
				createElementLinkMap.Add(typeof(AbstractionModelIsForORMModel), 1);
				createElementLinkMap.Add(typeof(ConceptTypeIsForObjectType), 2);
				createElementLinkMap.Add(typeof(ConceptTypeChildHasPathFactType), 3);
				createElementLinkMap.Add(typeof(InformationTypeFormatIsForValueType), 4);
				createElementLinkMap.Add(typeof(UniquenessIsForUniquenessConstraint), 5);
				createElementLinkMap.Add(typeof(ExcludedORMModelElement), 6);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				throw new global::System.ArgumentException("elementLinkType is not recognized as a type of domain relationship which belongs to this domain model.");
			}
			switch (index)
			{
				// A constructor was not generated for FactTypeMapsTowardsRole because it had HasCustomConstructor
				// set to true. Please provide the constructor below.
				case 0: return new FactTypeMapsTowardsRole(partition, roleAssignments, propertyAssignments);
				case 1: return new AbstractionModelIsForORMModel(partition, roleAssignments, propertyAssignments);
				case 2: return new ConceptTypeIsForObjectType(partition, roleAssignments, propertyAssignments);
				case 3: return new ConceptTypeChildHasPathFactType(partition, roleAssignments, propertyAssignments);
				case 4: return new InformationTypeFormatIsForValueType(partition, roleAssignments, propertyAssignments);
				case 5: return new UniquenessIsForUniquenessConstraint(partition, roleAssignments, propertyAssignments);
				case 6: return new ExcludedORMModelElement(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion
		#region Resource manager
		
		private static global::System.Resources.ResourceManager resourceManager;
		
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx";
		
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return ORMToORMAbstractionBridgeDomainModel.SingletonResourceManager;
			}
		}
	
		/// <summary>
		/// Gets the Singleton ResourceManager for this domain model.
		/// </summary>
		public static global::System.Resources.ResourceManager SingletonResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				if (ORMToORMAbstractionBridgeDomainModel.resourceManager == null)
				{
					ORMToORMAbstractionBridgeDomainModel.resourceManager = new global::System.Resources.ResourceManager(ResourceBaseName, typeof(ORMToORMAbstractionBridgeDomainModel).Assembly);
				}
				return ORMToORMAbstractionBridgeDomainModel.resourceManager;
			}
		}
		#endregion
		#region Copy/Remove closures
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter copyClosure;
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter removeClosure;
		/// <summary>
		/// Returns an IElementVisitorFilter that corresponds to the ClosureType.
		/// </summary>
		/// <param name="type">closure type</param>
		/// <param name="rootElements">collection of root elements</param>
		/// <returns>IElementVisitorFilter or null</returns>
		public override DslModeling::IElementVisitorFilter GetClosureFilter(DslModeling::ClosureType type, global::System.Collections.Generic.ICollection<DslModeling::ModelElement> rootElements)
		{
			switch (type)
			{
				case DslModeling::ClosureType.CopyClosure:
					return ORMToORMAbstractionBridgeDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return ORMToORMAbstractionBridgeDomainModel.DeleteClosure;
			}
			return base.GetClosureFilter(type, rootElements);
		}
		/// <summary>
		/// CopyClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter CopyClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (ORMToORMAbstractionBridgeDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new ORMToORMAbstractionBridgeCopyClosure());
					
					ORMToORMAbstractionBridgeDomainModel.copyClosure = copyFilter;
				}
				return ORMToORMAbstractionBridgeDomainModel.copyClosure;
			}
		}
		/// <summary>
		/// DeleteClosure cache
		/// </summary>
		private static DslModeling::IElementVisitorFilter DeleteClosure
		{
			get
			{
				// Incorporate all of the closures from the models we extend
				if (ORMToORMAbstractionBridgeDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new ORMToORMAbstractionBridgeDeleteClosure());
		
					ORMToORMAbstractionBridgeDomainModel.removeClosure = removeFilter;
				}
				return ORMToORMAbstractionBridgeDomainModel.removeClosure;
			}
		}
		#endregion
	}
		
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ORMToORMAbstractionBridgeDeleteClosure : ORMToORMAbstractionBridgeDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMToORMAbstractionBridgeDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	public partial class ORMToORMAbstractionBridgeDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Generic.Dictionary<global::System.Guid, bool> domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMToORMAbstractionBridgeDeleteClosureBase()
		{
			#region Initialize DomainData Table
			DomainRoles.Add(global::Neumont.Tools.ORMToORMAbstractionBridge.UniquenessIsForUniquenessConstraint.UniquenessDomainRoleId, true);
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return DslModeling::VisitorFilterResult.Yes;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker that is traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			return this.DomainRoles.ContainsKey(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Generic.Dictionary<global::System.Guid, bool> DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Generic.Dictionary<global::System.Guid, bool>();
				}
				return this.domainRoles;
			}
		}
	
	}
	/// <summary>
	/// Copy closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ORMToORMAbstractionBridgeCopyClosure : ORMToORMAbstractionBridgeCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMToORMAbstractionBridgeCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	public partial class ORMToORMAbstractionBridgeCopyClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Generic.Dictionary<global::System.Guid, bool> domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMToORMAbstractionBridgeCopyClosureBase()
		{
			#region Initialize DomainData Table
			#endregion
		}
		/// <summary>
		/// Called to ask the filter if a particular relationship from a source element should be included in the traversal
		/// </summary>
		/// <param name="walker">ElementWalker traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="sourceRoleInfo">DomainRoleInfo of the role that the source element is playing in the relationship</param>
		/// <param name="domainRelationshipInfo">DomainRelationshipInfo for the ElementLink in question</param>
		/// <param name="targetRelationship">Relationship in question</param>
		/// <returns>Yes if the relationship should be traversed</returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRelationship(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::DomainRoleInfo sourceRoleInfo, DslModeling::DomainRelationshipInfo domainRelationshipInfo, DslModeling::ElementLink targetRelationship)
		{
			return this.DomainRoles.ContainsKey(sourceRoleInfo.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// Called to ask the filter if a particular role player should be Visited during traversal
		/// </summary>
		/// <param name="walker">ElementWalker traversing the model</param>
		/// <param name="sourceElement">Model Element playing the source role</param>
		/// <param name="elementLink">Element Link that forms the relationship to the role player in question</param>
		/// <param name="targetDomainRole">DomainRoleInfo of the target role</param>
		/// <param name="targetRolePlayer">Model Element that plays the target role in the relationship</param>
		/// <returns></returns>
		public virtual DslModeling::VisitorFilterResult ShouldVisitRolePlayer(DslModeling::ElementWalker walker, DslModeling::ModelElement sourceElement, DslModeling::ElementLink elementLink, DslModeling::DomainRoleInfo targetDomainRole, DslModeling::ModelElement targetRolePlayer)
		{
			return this.DomainRoles.ContainsKey(targetDomainRole.Id) ? DslModeling::VisitorFilterResult.Yes : DslModeling::VisitorFilterResult.DoNotCare;
		}
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Generic.Dictionary<global::System.Guid, bool> DomainRoles
		{
			get
			{
				if (this.domainRoles == null)
				{
					this.domainRoles = new global::System.Collections.Generic.Dictionary<global::System.Guid, bool>();
				}
				return this.domainRoles;
			}
		}
	
	}
	#endregion
		
}
namespace Neumont.Tools.ORMToORMAbstractionBridge
{
	/// <summary>
	/// DomainEnumeration: MappingDepth
	/// Specify whether a mapping is shallow (absorbs just the <see
	/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> only) or deep (absorbs the <see
	/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> and the opposite <see
	/// cref="Neumont.Tools.ORM.ObjectModel.ObjectType">role player</see>.
	/// </summary>
	[global::System.ComponentModel.TypeConverter(typeof(global::Neumont.Tools.Modeling.Design.EnumConverter<MappingDepth, global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel>))]
	[global::System.Serializable()]
	[global::System.CLSCompliant(true)]
	public enum MappingDepth
	{
		/// <summary>
		/// Shallow
		/// Only the <see cref="Neumont.Tools.ORM.ObjectModel.FactType"/> referenced is
		/// mapped to the destination <see
		/// cref="Neumont.Tools.ORM.ObjectModel.ObjectType"/>.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingDepth/Shallow.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		Shallow = 0,
		/// <summary>
		/// Deep
		/// The <see cref="Neumont.Tools.ORM.ObjectModel.FactType"/> referenced is mapped to
		/// the destination <see cref="Neumont.Tools.ORM.ObjectModel.ObjectType"/>, and the
		/// <see cref="Neumont.Tools.ORM.ObjectModel.ObjectType"/> playing the opposite role
		/// is absorbed into the destination <see
		/// cref="Neumont.Tools.ORM.ObjectModel.ObjectType"/>.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingDepth/Deep.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		Deep = 1,
	}
}
namespace Neumont.Tools.ORMToORMAbstractionBridge
{
	/// <summary>
	/// DomainEnumeration: MappingUniquenessPattern
	/// Specifies the uniqueness pattern present on the <see
	/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> at the time the <see
	/// cref="FactTypeMapsTowardsRole"/> relationship was last updated.
	/// </summary>
	[global::System.ComponentModel.TypeConverter(typeof(global::Neumont.Tools.Modeling.Design.EnumConverter<MappingUniquenessPattern, global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel>))]
	[global::System.Serializable()]
	[global::System.CLSCompliant(true)]
	public enum MappingUniquenessPattern
	{
		/// <summary>
		/// None
		/// Uniqueness pattern not specified
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingUniquenessPattern/None.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		None = 0,
		/// <summary>
		/// OneToMany
		/// The mapping is based on a one-to-many <see
		/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> with a <see
		/// cref="Neumont.Tools.ORM.ObjectModel.UniquenessConstraint"/> on the <see
		/// cref="FactTypeMapsTowardsRole.TowardsRole"/>.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingUniquenessPattern/OneToMany.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		OneToMany = 1,
		/// <summary>
		/// ManyToOne
		/// The mapping is based on a many-to-one <see
		/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> with a <see
		/// cref="Neumont.Tools.ORM.ObjectModel.UniquenessConstraint"/> on the role opposite
		/// <see cref="FactTypeMapsTowardsRole.TowardsRole"/>. Note that this value is
		/// included for completeness and will not appear in actual <see
		/// cref="FactTypeMapsTowardsRole"/> instances.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingUniquenessPattern/ManyToOne.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		ManyToOne = 2,
		/// <summary>
		/// OneToOne
		/// The mapping is based on a one-to-one <see
		/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/>.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingUniquenessPattern/OneToOne.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		OneToOne = 3,
		/// <summary>
		/// Subtype
		/// The mapping is based on a <see
		/// cref="Neumont.Tools.ORM.ObjectModel.SubtypeFact"/> with the <see
		/// cref="FactTypeMapsTowardsRole.TowardsRole"/> acting as the superttype.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingUniquenessPattern/Subtype.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		Subtype = 4,
	}
}
namespace Neumont.Tools.ORMToORMAbstractionBridge
{
	/// <summary>
	/// DomainEnumeration: MappingMandatoryPattern
	/// Specifies the mandatory pattern present on the <see
	/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> at the time the <see
	/// cref="FactTypeMapsTowardsRole"/> relationship was last updated. Indicated
	/// mandatory relationships include single-role implied mandatory constraints.
	/// </summary>
	[global::System.ComponentModel.TypeConverter(typeof(global::Neumont.Tools.Modeling.Design.EnumConverter<MappingMandatoryPattern, global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel>))]
	[global::System.Serializable()]
	[global::System.CLSCompliant(true)]
	public enum MappingMandatoryPattern
	{
		/// <summary>
		/// None
		/// Mandatory pattern not specified
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingMandatoryPattern/None.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		None = 0,
		/// <summary>
		/// NotMandatory
		/// The <see cref="Neumont.Tools.ORM.ObjectModel.FactType"/> has no mandatory roles.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingMandatoryPattern/NotMandatory.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		NotMandatory = 1,
		/// <summary>
		/// TowardsRoleMandatory
		/// The <see cref="FactTypeMapsTowardsRole.TowardsRole"/> of the <see
		/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> is mandatory.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingMandatoryPattern/TowardsRoleMandatory.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		TowardsRoleMandatory = 2,
		/// <summary>
		/// OppositeRoleMandatory
		/// The role opposite <see cref="FactTypeMapsTowardsRole.TowardsRole"/> of the <see
		/// cref="Neumont.Tools.ORM.ObjectModel.FactType"/> is mandatory.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingMandatoryPattern/OppositeRoleMandatory.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		OppositeRoleMandatory = 3,
		/// <summary>
		/// BothRolesMandatory
		/// Both the <see cref="FactTypeMapsTowardsRole.TowardsRole"/> and opposite role of
		/// the <see cref="Neumont.Tools.ORM.ObjectModel.FactType"/> are mandatory.
		/// </summary>
		[DslDesign::DescriptionResource("Neumont.Tools.ORMToORMAbstractionBridge.MappingMandatoryPattern/BothRolesMandatory.Description", typeof(global::Neumont.Tools.ORMToORMAbstractionBridge.ORMToORMAbstractionBridgeDomainModel), "Neumont.Tools.ORMToORMAbstractionBridge.GeneratedCode.ORMToORMAbstractionBridgeDomainModelResx")]
		BothRolesMandatory = 4,
	}
}

