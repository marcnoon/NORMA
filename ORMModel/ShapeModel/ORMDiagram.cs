using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Design;
using System.Windows.Forms;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Diagrams;
using Northface.Tools.ORM.ObjectModel;
namespace Northface.Tools.ORM.ShapeModel
{
	public partial class ORMDiagram
	{
		#region Toolbox filter strings
		/// <summary>
		/// The filter string used for simple actions
		/// </summary>
		public const string ORMDiagramDefaultFilterString = "ORMDiagramDefaultFilterString";
		/// <summary>
		/// The filter string used to create an external constraint. Very similar to a
		/// normal action, except the external constraint connector is activated on completion
		/// of the action.
		/// </summary>
		public const string ORMDiagramExternalConstraintFilterString = "ORMDiagramExternalConstraintFilterString";
		/// <summary>
		/// The filter string used to connect role sets to external constraints
		/// </summary>
		public const string ORMDiagramConnectExternalConstraintFilterString = "ORMDiagramConnectExternalConstraintFilterString";
		#endregion // Toolbox filter strings
		#region View Fixup Methods
		/// <summary>
		/// Called as a result of the FixUpDiagram calls
		/// with the diagram as the first element.
		/// </summary>
		/// <param name="element">Added element</param>
		/// <returns>True for items displayed directly on the
		/// surface. Nesting object types are not displayed.</returns>
		protected override bool ShouldAddShapeForElement(ModelElement element)
		{
			ObjectType objType;
			if (element is FactType ||
				element is ObjectTypePlaysRole ||
				element is ExternalFactConstraint ||
				element is ExternalConstraint)
			{
				return true;
			}
			else if (null != (objType = element as ObjectType))
			{
				return objType.NestedFactType == null;
			}
			return base.ShouldAddShapeForElement(element);
		}
		/// <summary>
		/// An object type is displayed as an ObjectTypeShape unless it is
		/// objectified, in which case we display it as an ObjectifiedFactTypeNameShape
		/// </summary>
		/// <param name="element">The element to test. Expecting an ObjectType.</param>
		/// <param name="shapeTypes">The choice of shape types</param>
		/// <returns></returns>
		protected override MetaClassInfo ChooseShape(ModelElement element, IList shapeTypes)
		{
			Guid classId = element.MetaClassId;
			if (classId == ObjectType.MetaClassGuid)
			{
				return ChooseShapeTypeForObjectType((ObjectType)element, shapeTypes);
			}
			Debug.Assert(false); // We're only expecting an ObjectType here
			return base.ChooseShape(element, shapeTypes);
		}
		/// <summary>
		/// Helper function to choose the appropriate shape for an ObjectType
		/// UNDONE: The original plan was to override ChooseParentShape here to switch the
		/// parent to a FactType. However, the childShape passed to ChooseParentShape is not
		/// yet attached to its backing ModelElement, so the override is essentially useless,
		/// and we need to duplicate the ChooseShape code on FactTypeShape itself.
		/// </summary>
		/// <param name="element">ObjectType</param>
		/// <param name="shapeTypes">IList of MetaClassInfo</param>
		/// <returns></returns>
		public static MetaClassInfo ChooseShapeTypeForObjectType(ObjectType element, IList shapeTypes)
		{
			Guid shapeClassId = (element.NestedFactType == null) ? ObjectTypeShape.MetaClassGuid : ObjectifiedFactTypeNameShape.MetaClassGuid;
			foreach (MetaClassInfo classInfo in shapeTypes)
			{
				if (classInfo.Id == shapeClassId)
				{
					return classInfo;
				}
			}
			Debug.Assert(false); // Missed a shape associated with ObjectType
			return null;
		}
		/// <summary>
		/// Defer to ConfiguringAsChildOf for ORMBaseShape children
		/// </summary>
		/// <param name="child">The child being configured</param>
		protected override void OnChildConfiguring(ShapeElement child)
		{
			ORMBaseShape baseShape;
			RolePlayerLink roleLink;
			ExternalConstraintLink constraintLink;
			if (null != (baseShape = child as ORMBaseShape))
			{
				baseShape.ConfiguringAsChildOf(this);
			}
			else if (null != (roleLink = child as RolePlayerLink))
			{
				// UNDONE: Move this chunk of code elsewhere more specific
				// to a roleplayer link

				// If we're already connected then walk away
				if (roleLink.FromShape == null && roleLink.ToShape == null)
				{
					ObjectTypePlaysRole modelLink = roleLink.ModelElement as ObjectTypePlaysRole;
					ObjectType rolePlayer = modelLink.RolePlayer;
					FactType nestedFact = rolePlayer.NestedFactType;
					NodeShape fromShape;
					NodeShape toShape;
					if (null != (fromShape = FindShapeForElement(modelLink.PlayedRoleCollection.FactType) as NodeShape) &&
						null != (toShape = FindShapeForElement((nestedFact == null) ? rolePlayer as ModelElement : nestedFact) as NodeShape))
					{
						roleLink.Connect(fromShape, toShape);
					}
				}
			}
			else if (null != (constraintLink = child as ExternalConstraintLink))
			{
				// UNDONE: Move this chunk of code elsewhere more specific
				// to a roleplayer link

				// If we're already connected then walk away
				if (constraintLink.FromShape == null && constraintLink.ToShape == null)
				{
					ExternalFactConstraint modelLink = constraintLink.ModelElement as ExternalFactConstraint;
					FactType attachedFact = modelLink.FactTypeCollection;
					Constraint constraint = modelLink.ConstraintCollection;
					NodeShape fromShape;
					NodeShape toShape;
					if (null != (fromShape = FindShapeForElement(constraint) as NodeShape) &&
						null != (toShape = FindShapeForElement(attachedFact) as NodeShape))
					{
						constraintLink.Connect(fromShape, toShape);
					}
				}
			}
		}
		/// <summary>
		/// Locate an existing shape on this diagram corresponding to this element
		/// </summary>
		/// <param name="element">The element to search</param>
		/// <returns>An existing shape, or null if not found</returns>
		public ShapeElement FindShapeForElement(ModelElement element)
		{
			foreach (PresentationElement pel in element.AssociatedPresentationElements)
			{
				ShapeElement shape = pel as ShapeElement;
				if (shape != null && shape.Diagram == this)
				{
					return shape;
				}
			}
			return null;
		}
		#endregion // View Fixup Methods
		#region Toolbox initialization
		/// <summary>
		/// Initialize toolbox items. All items are thrown on the diagram (it doesn't
		/// really matter what object we put them on).
		/// </summary>
		/// <param name="toolboxItem"></param>
		/// <returns></returns>
		public override ElementGroupPrototype InitializeToolboxItem(ModelingToolboxItem toolboxItem)
		{
			Store store = Store;
			string itemId = toolboxItem.Id;
			ElementGroup group = new ElementGroup(store);
			ElementGroupPrototype retVal = null;
			int roleArity = 0;
			ExclusionType exclusionType = ExclusionType.Exclusion;
			switch (itemId)
			{
				case ResourceStrings.ToolboxEntityTypeItemId:
					ObjectType entityType = ObjectType.CreateObjectType(store);
					group.AddGraph(entityType);
					retVal = group.CreatePrototype(entityType);
					break;
				case ResourceStrings.ToolboxValueTypeItemId:
					ObjectType valueType = ObjectType.CreateObjectType(store);
					valueType.IsValueType = true;
					group.AddGraph(valueType);
					group.AddGraph(valueType.DataType);
					retVal = group.CreatePrototype(valueType);
					break;
				case ResourceStrings.ToolboxUnaryFactTypeItemId:
					roleArity = 1;
					break;
				case ResourceStrings.ToolboxBinaryFactTypeItemId:
					roleArity = 2;
					break;
				case ResourceStrings.ToolboxTernaryFactTypeItemId:
					roleArity = 3;
					break;
				case ResourceStrings.ToolboxExternalUniquenessConstraintItemId:
					ExternalUniquenessConstraint euc = ExternalUniquenessConstraint.CreateExternalUniquenessConstraint(store);
					group.AddGraph(euc);
					retVal = group.CreatePrototype(euc);
					break;
				case ResourceStrings.ToolboxEqualityConstraintItemId:
					EqualityConstraint eqc = EqualityConstraint.CreateEqualityConstraint(store);
					group.AddGraph(eqc);
					retVal = group.CreatePrototype(eqc);
					break;
				case ResourceStrings.ToolboxExclusionConstraintItemId:
					ExclusionConstraint exc = ExclusionConstraint.CreateExclusionConstraint(store);
					if (exclusionType != ExclusionType.Exclusion)
					{
						exc.ExclusionType = exclusionType;
					}
					group.AddGraph(exc);
					retVal = group.CreatePrototype(exc);
					break;
				case ResourceStrings.ToolboxInclusiveOrConstraintItemId:
					exclusionType = ExclusionType.InclusiveOr;
					goto case ResourceStrings.ToolboxExclusionConstraintItemId;
				case ResourceStrings.ToolboxExclusiveOrConstraintItemId:
					exclusionType = ExclusionType.ExclusiveOr;
					goto case ResourceStrings.ToolboxExclusionConstraintItemId;
				case ResourceStrings.ToolboxSubsetConstraintItemId:
					SubsetConstraint sc = SubsetConstraint.CreateSubsetConstraint(store);
					group.AddGraph(sc);
					retVal = group.CreatePrototype(sc);
					break;
				case ResourceStrings.ToolboxExternalConstraintConnectorItemId:
					// Intentionally unprototyped item
					break;
				default:
					Debug.Assert(false); // Unknown Id
					break;
			}
			if (retVal == null)
			{
				if (roleArity != 0)
				{
					FactType factType = FactType.CreateFactType(store);
					group.AddGraph(factType);
					RoleMoveableCollection roles = factType.RoleCollection;
					Role role;
					MetaAttributeInfo attrInfo = store.MetaDataDirectory.FindMetaAttribute(Role.NameMetaAttributeGuid);
					AttributeAssignment[] initialAttrs = new AttributeAssignment[1];
					string baseNamePattern = ResourceStrings.RoleDefaultNamePattern;
					for (int i = 0; i < roleArity; ++i)
					{
						initialAttrs[0] = new AttributeAssignment(attrInfo, string.Format(baseNamePattern, (i + 1).ToString()));
						role = Role.CreateAndInitializeRole(store, initialAttrs);
						roles.Add(role);
						group.AddGraph(role);
					}
					retVal = group.CreatePrototype(factType);
				}
			}
			return retVal;
		}
		#endregion // Toolbox initialization
		#region Toolbox support
		private ExternalConstraintConnectAction myExternalConstraintConnectAction;
		private ExternalConstraintAction myExternalConstraintAction;
		/// <summary>
		/// Enable our toolbox actions
		/// </summary>
		public override void OnViewMouseEnter(DiagramPointEventArgs pointArgs)
		{
			DiagramView activeView = ActiveDiagramView;
			MouseAction action = null;

			if (activeView != null)
			{
				if (activeView.SelectedToolboxItemSupportsFilterString(ORMDiagram.ORMDiagramConnectExternalConstraintFilterString))
				{
					action = ExternalConstraintConnectAction;
				}
				else if (activeView.SelectedToolboxItemSupportsFilterString(ORMDiagram.ORMDiagramExternalConstraintFilterString))
				{
					action = ExternalConstraintAction;
				}
				else if (activeView.SelectedToolboxItemSupportsFilterString(ORMDiagram.ORMDiagramDefaultFilterString))
				{
					action = ToolboxAction;
				}
			}

			DiagramClientView clientView = pointArgs.DiagramClientView;
			if (clientView.ActiveMouseAction != action)
			{
				clientView.ActiveMouseAction = action;
			}
		}
		private ExternalConstraintConnectAction ExternalConstraintConnectAction
		{
			get
			{
				if (myExternalConstraintConnectAction == null)
				{
					myExternalConstraintConnectAction = new ExternalConstraintConnectAction(this);
				}
				return myExternalConstraintConnectAction;
			}
		}
		private ExternalConstraintAction ExternalConstraintAction
		{
			get
			{
				if (myExternalConstraintAction == null)
				{
					myExternalConstraintAction = new ExternalConstraintAction(this);
					myExternalConstraintAction.AfterMouseActionDeactivated += delegate(object sender, DiagramEventArgs e)
					{
						ExternalConstraintAction action = sender as ExternalConstraintAction;
						if (action.ActionCompleted)
						{
							ExternalConstraintShape addedShape = action.AddedConstraintShape;
							Debug.Assert(addedShape != null); // ActionCompleted should be false otherwise
							ExternalConstraintConnectAction.ChainMouseAction(addedShape, e.DiagramClientView);
						}
					};
				}
				return myExternalConstraintAction;
			}
		}
		#endregion // Toolbox support
		#region Display Properties
		/// <summary>
		/// Retrieve the component name for the property grid. The
		/// component name is displayed bolded in the property grid dropdown
		/// before the class name (retrieved from GetClassName)
		/// </summary>
		/// <returns></returns>
		public override string GetComponentName()
		{
			ModelElement element = ModelElement;
			return (element != null) ? element.GetComponentName() : base.GetComponentName();
		}
		/// <summary>
		/// Block display of the diagram's name, which is displayed beside the
		/// Name for the underlying model if we let it through
		/// </summary>
		/// <param name="metaAttrInfo">MetaAttributeInfo</param>
		/// <returns>false for Diagram.Name, defers to base for all other attributes</returns>
		public override bool ShouldCreatePropertyDescriptor(MetaAttributeInfo metaAttrInfo)
		{
			Guid attributeGuid = metaAttrInfo.Id;
			if (attributeGuid == Diagram.NameMetaAttributeGuid)
			{
				return false;
			}
			return base.ShouldCreatePropertyDescriptor(metaAttrInfo);
		}
		#endregion // Display Properties
	}
}
