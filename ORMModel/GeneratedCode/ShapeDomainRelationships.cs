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

using DslModeling = Microsoft.VisualStudio.Modeling;
using DslDesign = Microsoft.VisualStudio.Modeling.Design;
namespace Neumont.Tools.ORM.ShapeModel
{
	/// <summary>
	/// DomainRelationship FactTypeShapeHasRoleDisplayOrder
	/// Description for Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder
	/// </summary>
	[DslDesign::DisplayNameResource("Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.DisplayName", typeof(global::Neumont.Tools.ORM.ShapeModel.ORMShapeModel), "Neumont.Tools.ORM.GeneratedCode.ShapeDomainModelResx")]
	[DslDesign::DescriptionResource("Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.Description", typeof(global::Neumont.Tools.ORM.ShapeModel.ORMShapeModel), "Neumont.Tools.ORM.GeneratedCode.ShapeDomainModelResx")]
	[global::System.CLSCompliant(true)]
	[DslModeling::DomainRelationship()]
	[DslModeling::DomainObjectId("94b3aeef-4c8d-4d1a-a7cc-42f7ebdc68a2")]
	public partial class FactTypeShapeHasRoleDisplayOrder : DslModeling::ElementLink
	{
		#region Constructors, domain class Id
		
		/// <summary>
		/// FactTypeShapeHasRoleDisplayOrder domain class Id.
		/// </summary>
		public static readonly new global::System.Guid DomainClassId = new global::System.Guid(0x94b3aeef, 0x4c8d, 0x4d1a, 0xa7, 0xcc, 0x42, 0xf7, 0xeb, 0xdc, 0x68, 0xa2);
	
				
		/// <summary>
		/// Constructor
		/// Creates a FactTypeShapeHasRoleDisplayOrder link in the same Partition as the given FactTypeShape
		/// </summary>
		/// <param name="source">FactTypeShape to use as the source of the relationship.</param>
		/// <param name="target">RoleBase to use as the target of the relationship.</param>
		public FactTypeShapeHasRoleDisplayOrder(FactTypeShape source, global::Neumont.Tools.ORM.ObjectModel.RoleBase target)
			: base((source != null ? source.Partition : null), new DslModeling::RoleAssignment[]{new DslModeling::RoleAssignment(FactTypeShapeHasRoleDisplayOrder.FactTypeShapeDomainRoleId, source), new DslModeling::RoleAssignment(FactTypeShapeHasRoleDisplayOrder.RoleDisplayOrderDomainRoleId, target)}, null)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public FactTypeShapeHasRoleDisplayOrder(DslModeling::Store store, params DslModeling::RoleAssignment[] roleAssignments)
			: base(store != null ? store.DefaultPartition : null, roleAssignments, null)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="store">Store where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public FactTypeShapeHasRoleDisplayOrder(DslModeling::Store store, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(store != null ? store.DefaultPartition : null, roleAssignments, propertyAssignments)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		public FactTypeShapeHasRoleDisplayOrder(DslModeling::Partition partition, params DslModeling::RoleAssignment[] roleAssignments)
			: base(partition, roleAssignments, null)
		{
		}
		
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="partition">Partition where new link is to be created.</param>
		/// <param name="roleAssignments">List of relationship role assignments.</param>
		/// <param name="propertyAssignments">List of properties assignments to set on the new link.</param>
		public FactTypeShapeHasRoleDisplayOrder(DslModeling::Partition partition, DslModeling::RoleAssignment[] roleAssignments, DslModeling::PropertyAssignment[] propertyAssignments)
			: base(partition, roleAssignments, propertyAssignments)
		{
		}
		#endregion
		#region FactTypeShape domain role code
		
		/// <summary>
		/// FactTypeShape domain role Id.
		/// </summary>
		public static readonly global::System.Guid FactTypeShapeDomainRoleId = new global::System.Guid(0x30c6b725, 0x2d74, 0x47f7, 0x85, 0x2a, 0xd0, 0x2c, 0x64, 0x4a, 0x44, 0x7b);
		
		/// <summary>
		/// DomainRole FactTypeShape
		/// Description for Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.Fa
		/// ctTypeShape
		/// </summary>
		[DslDesign::DisplayNameResource("Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder/FactTypeShape.DisplayName", typeof(global::Neumont.Tools.ORM.ShapeModel.ORMShapeModel), "Neumont.Tools.ORM.GeneratedCode.ShapeDomainModelResx")]
		[DslDesign::DescriptionResource("Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder/FactTypeShape.Description", typeof(global::Neumont.Tools.ORM.ShapeModel.ORMShapeModel), "Neumont.Tools.ORM.GeneratedCode.ShapeDomainModelResx")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Source, PropertyName = "RoleDisplayOrderCollection", PropertyDisplayNameKey="Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder/FactTypeShape.PropertyDisplayName", Multiplicity = DslModeling::Multiplicity.OneMany)]
		[DslModeling::DomainObjectId("30c6b725-2d74-47f7-852a-d02c644a447b")]
		public virtual FactTypeShape FactTypeShape
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (FactTypeShape)DslModeling::DomainRoleInfo.GetRolePlayer(this, FactTypeShapeDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, FactTypeShapeDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access FactTypeShapeCollection of a RoleBase
		/// <summary>
		/// Gets a list of FactTypeShapeCollection.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<FactTypeShape> GetFactTypeShapeCollection(global::Neumont.Tools.ORM.ObjectModel.RoleBase element)
		{
			return new DslModeling::LinkedElementCollection<FactTypeShape>(element, RoleDisplayOrderDomainRoleId);
		}
		#endregion
		#region RoleDisplayOrder domain role code
		
		/// <summary>
		/// RoleDisplayOrder domain role Id.
		/// </summary>
		public static readonly global::System.Guid RoleDisplayOrderDomainRoleId = new global::System.Guid(0x4ca45c6e, 0x0400, 0x4976, 0xaf, 0x8c, 0x0c, 0xad, 0x7c, 0x7b, 0xc2, 0xee);
		
		/// <summary>
		/// DomainRole RoleDisplayOrder
		/// Description for Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.Ro
		/// leDisplayOrder
		/// </summary>
		[DslDesign::DisplayNameResource("Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder/RoleDisplayOrder.DisplayName", typeof(global::Neumont.Tools.ORM.ShapeModel.ORMShapeModel), "Neumont.Tools.ORM.GeneratedCode.ShapeDomainModelResx")]
		[DslDesign::DescriptionResource("Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder/RoleDisplayOrder.Description", typeof(global::Neumont.Tools.ORM.ShapeModel.ORMShapeModel), "Neumont.Tools.ORM.GeneratedCode.ShapeDomainModelResx")]
		[DslModeling::DomainRole(DslModeling::DomainRoleOrder.Target, PropertyName = "FactTypeShapeCollection", PropertyDisplayNameKey="Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder/RoleDisplayOrder.PropertyDisplayName", Multiplicity = DslModeling::Multiplicity.OneMany)]
		[DslModeling::DomainObjectId("4ca45c6e-0400-4976-af8c-0cad7c7bc2ee")]
		public virtual global::Neumont.Tools.ORM.ObjectModel.RoleBase RoleDisplayOrder
		{
			[global::System.Diagnostics.DebuggerStepThrough]
			get
			{
				return (global::Neumont.Tools.ORM.ObjectModel.RoleBase)DslModeling::DomainRoleInfo.GetRolePlayer(this, RoleDisplayOrderDomainRoleId);
			}
			[global::System.Diagnostics.DebuggerStepThrough]
			set
			{
				DslModeling::DomainRoleInfo.SetRolePlayer(this, RoleDisplayOrderDomainRoleId, value);
			}
		}
				
		#endregion
		#region Static methods to access RoleDisplayOrderCollection of a FactTypeShape
		/// <summary>
		/// Gets a list of RoleDisplayOrderCollection.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static DslModeling::LinkedElementCollection<global::Neumont.Tools.ORM.ObjectModel.RoleBase> GetRoleDisplayOrderCollection(FactTypeShape element)
		{
			return new DslModeling::LinkedElementCollection<global::Neumont.Tools.ORM.ObjectModel.RoleBase>(element, FactTypeShapeDomainRoleId);
		}
		#endregion
		#region FactTypeShape link accessor
		/// <summary>
		/// Get the list of FactTypeShapeHasRoleDisplayOrder links to a FactTypeShape.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder> GetLinksToRoleDisplayOrderCollection ( global::Neumont.Tools.ORM.ShapeModel.FactTypeShape @factTypeShape )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder>(@factTypeShape, global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.FactTypeShapeDomainRoleId);
		}
		#endregion
		#region RoleDisplayOrder link accessor
		/// <summary>
		/// Get the list of FactTypeShapeHasRoleDisplayOrder links to a RoleBase.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder> GetLinksToFactTypeShapeCollection ( global::Neumont.Tools.ORM.ObjectModel.RoleBase @roleDisplayOrder )
		{
			return DslModeling::DomainRoleInfo.GetElementLinks<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder>(@roleDisplayOrder, global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.RoleDisplayOrderDomainRoleId);
		}
		#endregion
		#region FactTypeShapeHasRoleDisplayOrder instance accessors
		
		/// <summary>
		/// Get any FactTypeShapeHasRoleDisplayOrder links between a given FactTypeShape and a RoleBase.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::System.Collections.ObjectModel.ReadOnlyCollection<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder> GetLinks( global::Neumont.Tools.ORM.ShapeModel.FactTypeShape source, global::Neumont.Tools.ORM.ObjectModel.RoleBase target )
		{
			global::System.Collections.Generic.List<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder> outLinks = new global::System.Collections.Generic.List<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder>();
			global::System.Collections.Generic.IList<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder>(source, global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.FactTypeShapeDomainRoleId);
			foreach ( global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder link in links )
			{
				if ( target.Equals(link.RoleDisplayOrder) )
				{
					outLinks.Add(link);
				}
			}
			return outLinks.AsReadOnly();
		}
		/// <summary>
		/// Get the one FactTypeShapeHasRoleDisplayOrder link between a given FactTypeShapeand a RoleBase.
		/// </summary>
		[global::System.Diagnostics.DebuggerStepThrough]
		[global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1011")]
		public static global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder GetLink( global::Neumont.Tools.ORM.ShapeModel.FactTypeShape source, global::Neumont.Tools.ORM.ObjectModel.RoleBase target )
		{
			global::System.Collections.Generic.IList<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder> links = DslModeling::DomainRoleInfo.GetElementLinks<global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder>(source, global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder.FactTypeShapeDomainRoleId);
			foreach ( global::Neumont.Tools.ORM.ShapeModel.FactTypeShapeHasRoleDisplayOrder link in links )
			{
				if ( target.Equals(link.RoleDisplayOrder) )
				{
					return link;
				}
			}
			return null;
		}
		
		#endregion
	}
}
