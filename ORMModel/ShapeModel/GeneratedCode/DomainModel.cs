﻿#region Common Public License Copyright Notice
/**************************************************************************\
* Natural Object-Role Modeling Architect for Visual Studio                 *
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
using DslDiagrams = global::Microsoft.VisualStudio.Modeling.Diagrams;
namespace ORMSolutions.ORMArchitect.Core.ShapeModel
{
	/// <summary>
	/// DomainModel ORMShapeDomainModel
	/// Description for ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShape
	/// </summary>
	[DslModeling::ExtendsDomainModel("F60BC3F1-C38E-4C7D-9EE5-9211DB26CB45"/*ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel*/)]
	[DslModeling::ExtendsDomainModel("3EAE649F-E654-4D04-8289-C25D2C0322D8"/*ORMSolutions.ORMArchitect.Core.ObjectModel.ORMCoreDomainModel*/)]
	[DslModeling::ExtendsDomainModel("91D59B16-E488-4A28-8D51-59273AD5BF2E"/*Microsoft.VisualStudio.Modeling.Diagrams.CoreDesignSurfaceDomainModel*/)]
	[DslDesign::DisplayNameResource("ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel.DisplayName", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
	[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DomainObjectId("c52fb9a5-6bf4-4267-8716-71d74c7aa89c")]
	public partial class ORMShapeDomainModel : DslModeling::DomainModel
	{
		#region Constructor, domain model Id
	
		/// <summary>
		/// ORMShapeDomainModel domain model Id.
		/// </summary>
		public static readonly global::System.Guid DomainModelId = new global::System.Guid(0xc52fb9a5, 0x6bf4, 0x4267, 0x87, 0x16, 0x71, 0xd7, 0x4c, 0x7a, 0xa8, 0x9c);
	
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store">Store containing the domain model.</param>
		public ORMShapeDomainModel(DslModeling::Store store)
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
				typeof(FactTypeShapeHasRoleDisplayOrder),
				typeof(ORMDiagram),
				typeof(ORMBaseBinaryLinkShape),
				typeof(ORMDirectBinaryLinkShape),
				typeof(RolePlayerLink),
				typeof(RolePlayerProxyLink),
				typeof(ExternalConstraintLink),
				typeof(ValueRangeLink),
				typeof(ModelNoteLink),
				typeof(ORMBaseShape),
				typeof(ObjectTypeShape),
				typeof(FactTypeShape),
				typeof(SubtypeLink),
				typeof(ExternalConstraintShape),
				typeof(FrequencyConstraintShape),
				typeof(RingConstraintShape),
				typeof(FloatingTextShape),
				typeof(ObjectifiedFactTypeNameShape),
				typeof(ReadingShape),
				typeof(ValueConstraintShape),
				typeof(RoleNameShape),
				typeof(ModelNoteShape),
				typeof(LinkConnectorShape),
				typeof(FactTypeLinkConnectorShape),
				typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.FixUpDiagram),
				typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ConnectorRolePlayerChanged),
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
				new DomainMemberInfo(typeof(ORMDiagram), "AutoPopulateShapes", ORMDiagram.AutoPopulateShapesDomainPropertyId, typeof(ORMDiagram.AutoPopulateShapesPropertyHandler)),
				new DomainMemberInfo(typeof(ORMBaseBinaryLinkShape), "UpdateCounter", ORMBaseBinaryLinkShape.UpdateCounterDomainPropertyId, typeof(ORMBaseBinaryLinkShape.UpdateCounterPropertyHandler)),
				new DomainMemberInfo(typeof(ORMBaseShape), "UpdateCounter", ORMBaseShape.UpdateCounterDomainPropertyId, typeof(ORMBaseShape.UpdateCounterPropertyHandler)),
				new DomainMemberInfo(typeof(ObjectTypeShape), "ExpandRefMode", ObjectTypeShape.ExpandRefModeDomainPropertyId, typeof(ObjectTypeShape.ExpandRefModePropertyHandler)),
				new DomainMemberInfo(typeof(ObjectTypeShape), "DisplayRelatedTypes", ObjectTypeShape.DisplayRelatedTypesDomainPropertyId, typeof(ObjectTypeShape.DisplayRelatedTypesPropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeShape), "ConstraintDisplayPosition", FactTypeShape.ConstraintDisplayPositionDomainPropertyId, typeof(FactTypeShape.ConstraintDisplayPositionPropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeShape), "DisplayRoleNames", FactTypeShape.DisplayRoleNamesDomainPropertyId, typeof(FactTypeShape.DisplayRoleNamesPropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeShape), "DisplayOrientation", FactTypeShape.DisplayOrientationDomainPropertyId, typeof(FactTypeShape.DisplayOrientationPropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeShape), "DisplayRelatedTypes", FactTypeShape.DisplayRelatedTypesDomainPropertyId, typeof(FactTypeShape.DisplayRelatedTypesPropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeShape), "DisplayAsObjectType", FactTypeShape.DisplayAsObjectTypeDomainPropertyId, typeof(FactTypeShape.DisplayAsObjectTypePropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeShape), "ExpandRefMode", FactTypeShape.ExpandRefModeDomainPropertyId, typeof(FactTypeShape.ExpandRefModePropertyHandler)),
				new DomainMemberInfo(typeof(FactTypeShape), "RolesPosition", FactTypeShape.RolesPositionDomainPropertyId, typeof(FactTypeShape.RolesPositionPropertyHandler)),
				new DomainMemberInfo(typeof(ObjectifiedFactTypeNameShape), "ExpandRefMode", ObjectifiedFactTypeNameShape.ExpandRefModeDomainPropertyId, typeof(ObjectifiedFactTypeNameShape.ExpandRefModePropertyHandler)),
				new DomainMemberInfo(typeof(ValueConstraintShape), "MaximumDisplayedValues", ValueConstraintShape.MaximumDisplayedValuesDomainPropertyId, typeof(ValueConstraintShape.MaximumDisplayedValuesPropertyHandler)),
				new DomainMemberInfo(typeof(ValueConstraintShape), "MaximumDisplayedColumns", ValueConstraintShape.MaximumDisplayedColumnsDomainPropertyId, typeof(ValueConstraintShape.MaximumDisplayedColumnsPropertyHandler)),
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
				new DomainRolePlayerInfo(typeof(FactTypeShapeHasRoleDisplayOrder), "FactTypeShape", FactTypeShapeHasRoleDisplayOrder.FactTypeShapeDomainRoleId),
				new DomainRolePlayerInfo(typeof(FactTypeShapeHasRoleDisplayOrder), "RoleDisplayOrder", FactTypeShapeHasRoleDisplayOrder.RoleDisplayOrderDomainRoleId),
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
				createElementMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(23);
				createElementMap.Add(typeof(ORMDiagram), 0);
				createElementMap.Add(typeof(RolePlayerLink), 1);
				createElementMap.Add(typeof(RolePlayerProxyLink), 2);
				createElementMap.Add(typeof(ExternalConstraintLink), 3);
				createElementMap.Add(typeof(ValueRangeLink), 4);
				createElementMap.Add(typeof(ModelNoteLink), 5);
				createElementMap.Add(typeof(ObjectTypeShape), 6);
				createElementMap.Add(typeof(FactTypeShape), 7);
				createElementMap.Add(typeof(SubtypeLink), 8);
				createElementMap.Add(typeof(ExternalConstraintShape), 9);
				createElementMap.Add(typeof(FrequencyConstraintShape), 10);
				createElementMap.Add(typeof(RingConstraintShape), 11);
				createElementMap.Add(typeof(ObjectifiedFactTypeNameShape), 12);
				createElementMap.Add(typeof(ReadingShape), 13);
				createElementMap.Add(typeof(ValueConstraintShape), 14);
				createElementMap.Add(typeof(RoleNameShape), 15);
				createElementMap.Add(typeof(ModelNoteShape), 16);
				createElementMap.Add(typeof(LinkConnectorShape), 17);
				createElementMap.Add(typeof(FactTypeLinkConnectorShape), 18);
			}
			int index;
			if (!createElementMap.TryGetValue(elementType, out index))
			{
				throw new global::System.ArgumentException("elementType is not recognized as a type of domain class which belongs to this domain model.");
			}
			switch (index)
			{
				// A constructor was not generated for ORMDiagram because it had HasCustomConstructor
				// set to true. Please provide the constructor below.
				case 0: return new ORMDiagram(partition, propertyAssignments);
				case 1: return new RolePlayerLink(partition, propertyAssignments);
				case 2: return new RolePlayerProxyLink(partition, propertyAssignments);
				case 3: return new ExternalConstraintLink(partition, propertyAssignments);
				case 4: return new ValueRangeLink(partition, propertyAssignments);
				case 5: return new ModelNoteLink(partition, propertyAssignments);
				case 6: return new ObjectTypeShape(partition, propertyAssignments);
				case 7: return new FactTypeShape(partition, propertyAssignments);
				case 8: return new SubtypeLink(partition, propertyAssignments);
				case 9: return new ExternalConstraintShape(partition, propertyAssignments);
				case 10: return new FrequencyConstraintShape(partition, propertyAssignments);
				case 11: return new RingConstraintShape(partition, propertyAssignments);
				case 12: return new ObjectifiedFactTypeNameShape(partition, propertyAssignments);
				case 13: return new ReadingShape(partition, propertyAssignments);
				case 14: return new ValueConstraintShape(partition, propertyAssignments);
				case 15: return new RoleNameShape(partition, propertyAssignments);
				case 16: return new ModelNoteShape(partition, propertyAssignments);
				case 17: return new LinkConnectorShape(partition, propertyAssignments);
				case 18: return new FactTypeLinkConnectorShape(partition, propertyAssignments);
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
				createElementLinkMap = new global::System.Collections.Generic.Dictionary<global::System.Type, int>(1);
				createElementLinkMap.Add(typeof(FactTypeShapeHasRoleDisplayOrder), 0);
			}
			int index;
			if (!createElementLinkMap.TryGetValue(elementLinkType, out index))
			{
				throw new global::System.ArgumentException("elementLinkType is not recognized as a type of domain relationship which belongs to this domain model.");
			}
			switch (index)
			{
				case 0: return new FactTypeShapeHasRoleDisplayOrder(partition, roleAssignments, propertyAssignments);
				default: return null;
			}
		}
		#endregion
		#region Resource manager
		
		private static global::System.Resources.ResourceManager resourceManager;
		
		/// <summary>
		/// The base name of this model's resources.
		/// </summary>
		public const string ResourceBaseName = "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx";
		
		/// <summary>
		/// Gets the DomainModel's ResourceManager. If the ResourceManager does not already exist, then it is created.
		/// </summary>
		public override global::System.Resources.ResourceManager ResourceManager
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return ORMShapeDomainModel.SingletonResourceManager;
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
				if (ORMShapeDomainModel.resourceManager == null)
				{
					ORMShapeDomainModel.resourceManager = new global::System.Resources.ResourceManager(ResourceBaseName, typeof(ORMShapeDomainModel).Assembly);
				}
				return ORMShapeDomainModel.resourceManager;
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
					return ORMShapeDomainModel.CopyClosure;
				case DslModeling::ClosureType.DeleteClosure:
					return ORMShapeDomainModel.DeleteClosure;
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
				if (ORMShapeDomainModel.copyClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter copyFilter = new DslModeling::ChainingElementVisitorFilter();
					copyFilter.AddFilter(new ORMShapeCopyClosure());
					copyFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceCopyClosure());
					
					ORMShapeDomainModel.copyClosure = copyFilter;
				}
				return ORMShapeDomainModel.copyClosure;
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
				if (ORMShapeDomainModel.removeClosure == null)
				{
					DslModeling::ChainingElementVisitorFilter removeFilter = new DslModeling::ChainingElementVisitorFilter();
					removeFilter.AddFilter(new ORMShapeDeleteClosure());
					removeFilter.AddFilter(new DslDiagrams::CoreDesignSurfaceDeleteClosure());
		
					ORMShapeDomainModel.removeClosure = removeFilter;
				}
				return ORMShapeDomainModel.removeClosure;
			}
		}
		#endregion
		#region Diagram rule helpers
		/// <summary>
		/// Enables rules in this domain model related to diagram fixup for the given store.
		/// If diagram data will be loaded into the store, this method should be called first to ensure
		/// that the diagram behaves properly.
		/// </summary>
		public static void EnableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.EnableRule(typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.FixUpDiagram));
			ruleManager.EnableRule(typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ConnectorRolePlayerChanged));
		}
		
		/// <summary>
		/// Disables rules in this domain model related to diagram fixup for the given store.
		/// </summary>
		public static void DisableDiagramRules(DslModeling::Store store)
		{
			if(store == null) throw new global::System.ArgumentNullException("store");
			
			DslModeling::RuleManager ruleManager = store.RuleManager;
			ruleManager.DisableRule(typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.FixUpDiagram));
			ruleManager.DisableRule(typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ConnectorRolePlayerChanged));
		}
		#endregion
	}
		
	#region Copy/Remove closure classes
	/// <summary>
	/// Remove closure visitor filter
	/// </summary>
	[global::System.CLSCompliant(true)]
	public partial class ORMShapeDeleteClosure : ORMShapeDeleteClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMShapeDeleteClosure() : base()
		{
		}
	}
	
	/// <summary>
	/// Base class for remove closure visitor filter
	/// </summary>
	public partial class ORMShapeDeleteClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Generic.Dictionary<global::System.Guid, bool> domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMShapeDeleteClosureBase()
		{
			#region Initialize DomainData Table
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
	public partial class ORMShapeCopyClosure : ORMShapeCopyClosureBase, DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMShapeCopyClosure() : base()
		{
		}
	}
	/// <summary>
	/// Base class for copy closure visitor filter
	/// </summary>
	public partial class ORMShapeCopyClosureBase : DslModeling::IElementVisitorFilter
	{
		/// <summary>
		/// DomainRoles
		/// </summary>
		private global::System.Collections.Generic.Dictionary<global::System.Guid, bool> domainRoles;
		/// <summary>
		/// Constructor
		/// </summary>
		public ORMShapeCopyClosureBase()
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
namespace ORMSolutions.ORMArchitect.Core.ShapeModel
{
	/// <summary>
	/// DomainEnumeration: ConstraintDisplayPosition
	/// Determines where internal constraints are drawn on FactTypeShapes.
	/// </summary>
	[global::System.ComponentModel.TypeConverter(typeof(global::ORMSolutions.ORMArchitect.Framework.Design.EnumConverter<ConstraintDisplayPosition, global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMDiagram>))]
	[global::System.CLSCompliant(true)]
	public enum ConstraintDisplayPosition
	{
		/// <summary>
		/// Top
		/// Draw the constraints above the top of the role boxes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.ConstraintDisplayPosition/Top.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		Top = 0,
		/// <summary>
		/// Bottom
		/// Draw the constraints below the bottom of the role boxes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.ConstraintDisplayPosition/Bottom.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		Bottom = 1,
	}
}
namespace ORMSolutions.ORMArchitect.Core.ShapeModel
{
	/// <summary>
	/// DomainEnumeration: DisplayRoleNames
	/// Determines whether RoleNameShapes will be drawn for the Roles in the FactType
	/// represented by the FactTypeShape using this enumeration, overriding the global
	/// setting.
	/// </summary>
	[global::System.ComponentModel.TypeConverter(typeof(global::ORMSolutions.ORMArchitect.Framework.Design.EnumConverter<DisplayRoleNames, global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMDiagram>))]
	[global::System.CLSCompliant(true)]
	public enum DisplayRoleNames
	{
		/// <summary>
		/// UserDefault
		/// Use the global setting.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.DisplayRoleNames/UserDefault.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		UserDefault = 0,
		/// <summary>
		/// On
		/// Always draw the RoleNameShapes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.DisplayRoleNames/On.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		On = 1,
		/// <summary>
		/// Off
		/// Never draw the RoleNameShapes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.DisplayRoleNames/Off.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		Off = 2,
	}
}
namespace ORMSolutions.ORMArchitect.Core.ShapeModel
{
	/// <summary>
	/// DomainEnumeration: DisplayOrientation
	/// Determines whether a FactTypeShape is drawn horizontally or vertically.
	/// </summary>
	[global::System.ComponentModel.TypeConverter(typeof(global::ORMSolutions.ORMArchitect.Framework.Design.EnumConverter<DisplayOrientation, global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMDiagram>))]
	[global::System.CLSCompliant(true)]
	public enum DisplayOrientation
	{
		/// <summary>
		/// Horizontal
		/// The fact type is drawn with a horizontal orientation.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.DisplayOrientation/Horizontal.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		Horizontal = 0,
		/// <summary>
		/// VerticalRotatedRight
		/// The fact type is drawn with a vertical orientation rotated to the right.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.DisplayOrientation/VerticalRotatedRight.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		VerticalRotatedRight = 1,
		/// <summary>
		/// VerticalRotatedLeft
		/// The fact type is drawn with a vertical orientation rotated to the left.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.DisplayOrientation/VerticalRotatedLeft.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		VerticalRotatedLeft = 2,
	}
}
namespace ORMSolutions.ORMArchitect.Core.ShapeModel
{
	/// <summary>
	/// DomainEnumeration: RelatedTypesDisplay
	/// Determines whether an ObjectTypeShape or objectified FactTypeShape is attached
	/// to its supertypes or subtypes.
	/// </summary>
	[global::System.ComponentModel.TypeConverter(typeof(global::ORMSolutions.ORMArchitect.Framework.Design.EnumConverter<RelatedTypesDisplay, global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMDiagram>))]
	[global::System.CLSCompliant(true)]
	public enum RelatedTypesDisplay
	{
		/// <summary>
		/// AttachAllTypes
		/// The shape attaches to both its supertypes and its subtypes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.RelatedTypesDisplay/AttachAllTypes.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		AttachAllTypes = 0,
		/// <summary>
		/// AttachSubtypes
		/// The shape attaches to its subtypes, but not its supertypes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.RelatedTypesDisplay/AttachSubtypes.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		AttachSubtypes = 1,
		/// <summary>
		/// AttachSupertypes
		/// The shape attaches to its supertypes, but not its subtypes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.RelatedTypesDisplay/AttachSupertypes.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		AttachSupertypes = 2,
		/// <summary>
		/// AttachNoTypes
		/// The shape attaches to neither its subtypes nor its supertypes.
		/// </summary>
		[DslDesign::DescriptionResource("ORMSolutions.ORMArchitect.Core.ShapeModel.RelatedTypesDisplay/AttachNoTypes.Description", typeof(global::ORMSolutions.ORMArchitect.Core.ShapeModel.ORMShapeDomainModel), "ORMSolutions.ORMArchitect.Core.GeneratedCode.ShapeDomainModelResx")]
		AttachNoTypes = 3,
	}
}

