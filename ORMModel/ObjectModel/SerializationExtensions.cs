﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:2.0.40607.85
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

namespace Northface.Tools.ORM.ObjectModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using Microsoft.VisualStudio.Modeling;
    using Northface.Tools.ORM.Shell;
    
    /// <summary>
    ///</summary>
    public partial class ORMMetaModel : IORMCustomElementNamespace
    {
        /// <summary>
        ///</summary>
        protected string[,] GetCustomElementNamespaces()
        {
            string[,] ret = new string[1, 2];
            ret[0, 0] = "orm";
            ret[0, 1] = "http://Schemas.Northface.edu/ORM/ORMCore";
            return ret;
        }
        string[,] IORMCustomElementNamespace.GetCustomElementNamespaces()
        {
            return this.GetCustomElementNamespaces();
        }
    }
    /// <summary>
    ///</summary>
    public partial class ORMModel : IORMCustomSerializedElement
    {
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations GetSupportedOperations()
        {
            return (ORMCustomSerializedElementSupportedOperations.CustomSerializedCombinedElementInfo | ORMCustomSerializedElementSupportedOperations.CustomSerializedElementInfo);
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations IORMCustomSerializedElement.GetSupportedOperations()
        {
            return this.GetSupportedOperations();
        }
        /// <summary>
        ///</summary>
        protected bool HasMixedTypedAttributes()
        {
            return false;
        }
        bool IORMCustomSerializedElement.HasMixedTypedAttributes()
        {
            return this.HasMixedTypedAttributes();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] GetCustomSerializedCombinedElementInfo()
        {
            Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] ret = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[7];
            System.Guid[] guids0 = new System.Guid[1];
            guids0[0] = ModelHasObjectType.ObjectTypeCollectionMetaRoleGuid;
            ret[0] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("Objects", guids0);
            System.Guid[] guids1 = new System.Guid[1];
            guids1[0] = ModelHasFactType.FactTypeCollectionMetaRoleGuid;
            ret[1] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("Facts", guids1);
            System.Guid[] guids2 = new System.Guid[2];
            guids2[0] = ModelHasMultiColumnExternalConstraint.MultiColumnExternalConstraintCollectionMetaRoleGuid;
            guids2[1] = ModelHasSingleColumnExternalConstraint.SingleColumnExternalConstraintCollectionMetaRoleGuid;
            ret[2] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("ExternalConstraints", guids2);
            System.Guid[] guids3 = new System.Guid[1];
            guids3[0] = ModelHasDataType.DataTypeCollectionMetaRoleGuid;
            ret[3] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("DataTypes", guids3);
            System.Guid[] guids4 = new System.Guid[1];
            guids4[0] = ModelHasReferenceMode.ReferenceModeCollectionMetaRoleGuid;
            ret[4] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("CustomReferenceModes", guids4);
            System.Guid[] guids5 = new System.Guid[1];
            guids5[0] = ModelHasReferenceModeKind.ReferenceModeKindCollectionMetaRoleGuid;
            ret[5] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("IShouldntbeHere", guids5);
            System.Guid[] guids6 = new System.Guid[1];
            guids6[0] = ModelHasError.ErrorCollectionMetaRoleGuid;
            ret[6] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("ModelErrors", guids6);
            return ret;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] IORMCustomSerializedElement.GetCustomSerializedCombinedElementInfo()
        {
            return this.GetCustomSerializedCombinedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedElementInfo()
        {
            return new ORMCustomSerializedElementInfo(null, "Model", null, ORMCustomSerializedElementWriteStyle.Element, null);
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedElementInfo()
        {
            return this.GetCustomSerializedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo IORMCustomSerializedElement.GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedAttributeInfo(attributeInfo, rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedLinkInfo(rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected void SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
        }
        void IORMCustomSerializedElement.SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
            this.SortCustomSerializedChildRoles(playedMetaRoles);
        }
    }
    /// <summary>
    ///</summary>
    public partial class ObjectType : IORMCustomSerializedElement
    {
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations GetSupportedOperations()
        {
            return (ORMCustomSerializedElementSupportedOperations.CustomSerializedElementInfo 
                        | (ORMCustomSerializedElementSupportedOperations.CustomSerializedAttributeInfo | ORMCustomSerializedElementSupportedOperations.CustomSerializedLinkInfo));
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations IORMCustomSerializedElement.GetSupportedOperations()
        {
            return this.GetSupportedOperations();
        }
        /// <summary>
        ///</summary>
        protected bool HasMixedTypedAttributes()
        {
            return false;
        }
        bool IORMCustomSerializedElement.HasMixedTypedAttributes()
        {
            return this.HasMixedTypedAttributes();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] GetCustomSerializedCombinedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] IORMCustomSerializedElement.GetCustomSerializedCombinedElementInfo()
        {
            return this.GetCustomSerializedCombinedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedElementInfo()
        {
            string name = "EntityType";
            if (this.IsValueType)
            {
                name = "ValueType";
            }
            else
            {
                if ((this.NestedFactType != null))
                {
                    name = "ObjectifiedType";
                }
            }
            return new ORMCustomSerializedElementInfo(null, name, null, ORMCustomSerializedElementWriteStyle.Element, null);
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedElementInfo()
        {
            return this.GetCustomSerializedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((attributeInfo.Id == ObjectType.ReferenceModeStringMetaAttributeGuid))
            {
                return new ORMCustomSerializedAttributeInfo(null, "ReferenceMode", null, false, ORMCustomSerializedAttributeWriteStyle.Attribute, null);
            }
            return ORMCustomSerializedAttributeInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo IORMCustomSerializedElement.GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedAttributeInfo(attributeInfo, rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((rolePlayedInfo.Id == ObjectTypePlaysRole.PlayedRoleCollectionMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, "PlayedRole", null, ORMCustomSerializedElementWriteStyle.Element, null);
            }
            if ((rolePlayedInfo.Id == ValueTypeHasDataType.DataTypeMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, "ConceptualDataType", null, ORMCustomSerializedElementWriteStyle.Element, null);
            }
            if ((rolePlayedInfo.Id == SubjectHasPresentation.PresentationMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, null, null, ORMCustomSerializedElementWriteStyle.DontWrite, null);
            }
            if ((rolePlayedInfo.Id == NestingEntityTypeHasFactType.NestedFactTypeMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, "NestedPredicate", null, ORMCustomSerializedElementWriteStyle.Element, null);
            }
            return ORMCustomSerializedElementInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedLinkInfo(rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected void SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
        }
        void IORMCustomSerializedElement.SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
            this.SortCustomSerializedChildRoles(playedMetaRoles);
        }
    }
    /// <summary>
    ///</summary>
    public partial class ValueTypeHasDataType : IORMCustomSerializedElement
    {
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations GetSupportedOperations()
        {
            return ORMCustomSerializedElementSupportedOperations.CustomSerializedAttributeInfo;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations IORMCustomSerializedElement.GetSupportedOperations()
        {
            return this.GetSupportedOperations();
        }
        /// <summary>
        ///</summary>
        protected bool HasMixedTypedAttributes()
        {
            return true;
        }
        bool IORMCustomSerializedElement.HasMixedTypedAttributes()
        {
            return this.HasMixedTypedAttributes();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] GetCustomSerializedCombinedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] IORMCustomSerializedElement.GetCustomSerializedCombinedElementInfo()
        {
            return this.GetCustomSerializedCombinedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedElementInfo()
        {
            return this.GetCustomSerializedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((attributeInfo.Id == ValueTypeHasDataType.ScaleMetaAttributeGuid))
            {
                if ((rolePlayedInfo.Id == ValueTypeHasDataType.ValueTypeCollectionMetaRoleGuid))
                {
                    return new ORMCustomSerializedAttributeInfo(null, "Scale", null, false, ORMCustomSerializedAttributeWriteStyle.Attribute, null);
                }
                return new ORMCustomSerializedAttributeInfo(null, null, null, false, ORMCustomSerializedAttributeWriteStyle.Attribute, null);
            }
            return ORMCustomSerializedAttributeInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo IORMCustomSerializedElement.GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedAttributeInfo(attributeInfo, rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedLinkInfo(rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected void SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
        }
        void IORMCustomSerializedElement.SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
            this.SortCustomSerializedChildRoles(playedMetaRoles);
        }
    }
    /// <summary>
    ///</summary>
    public partial class DataType : IORMCustomSerializedElement
    {
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations GetSupportedOperations()
        {
            return ORMCustomSerializedElementSupportedOperations.CustomSerializedLinkInfo;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations IORMCustomSerializedElement.GetSupportedOperations()
        {
            return this.GetSupportedOperations();
        }
        /// <summary>
        ///</summary>
        protected bool HasMixedTypedAttributes()
        {
            return false;
        }
        bool IORMCustomSerializedElement.HasMixedTypedAttributes()
        {
            return this.HasMixedTypedAttributes();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] GetCustomSerializedCombinedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] IORMCustomSerializedElement.GetCustomSerializedCombinedElementInfo()
        {
            return this.GetCustomSerializedCombinedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedElementInfo()
        {
            return this.GetCustomSerializedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo IORMCustomSerializedElement.GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedAttributeInfo(attributeInfo, rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((rolePlayedInfo.Id == ValueTypeHasDataType.ValueTypeCollectionMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, null, null, ORMCustomSerializedElementWriteStyle.DontWrite, null);
            }
            return ORMCustomSerializedElementInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedLinkInfo(rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected void SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
        }
        void IORMCustomSerializedElement.SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
            this.SortCustomSerializedChildRoles(playedMetaRoles);
        }
    }
    /// <summary>
    ///</summary>
    public partial class ReferenceModeKind : IORMCustomSerializedElement
    {
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations GetSupportedOperations()
        {
            return ORMCustomSerializedElementSupportedOperations.CustomSerializedLinkInfo;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations IORMCustomSerializedElement.GetSupportedOperations()
        {
            return this.GetSupportedOperations();
        }
        /// <summary>
        ///</summary>
        protected bool HasMixedTypedAttributes()
        {
            return false;
        }
        bool IORMCustomSerializedElement.HasMixedTypedAttributes()
        {
            return this.HasMixedTypedAttributes();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] GetCustomSerializedCombinedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] IORMCustomSerializedElement.GetCustomSerializedCombinedElementInfo()
        {
            return this.GetCustomSerializedCombinedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedElementInfo()
        {
            return this.GetCustomSerializedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo IORMCustomSerializedElement.GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedAttributeInfo(attributeInfo, rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((rolePlayedInfo.Id == ReferenceModeHasReferenceModeKind.ReferenceModeCollectionMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, "IAmLinkedToAReferenceModeKind", null, ORMCustomSerializedElementWriteStyle.Element, null);
            }
            return ORMCustomSerializedElementInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedLinkInfo(rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected void SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
        }
        void IORMCustomSerializedElement.SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
            this.SortCustomSerializedChildRoles(playedMetaRoles);
        }
    }
    /// <summary>
    ///</summary>
    public partial class FactType : IORMCustomSerializedElement
    {
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations GetSupportedOperations()
        {
            return (ORMCustomSerializedElementSupportedOperations.CustomSerializedCombinedElementInfo 
                        | (ORMCustomSerializedElementSupportedOperations.CustomSerializedElementInfo | ORMCustomSerializedElementSupportedOperations.CustomSerializedLinkInfo));
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations IORMCustomSerializedElement.GetSupportedOperations()
        {
            return this.GetSupportedOperations();
        }
        /// <summary>
        ///</summary>
        protected bool HasMixedTypedAttributes()
        {
            return false;
        }
        bool IORMCustomSerializedElement.HasMixedTypedAttributes()
        {
            return this.HasMixedTypedAttributes();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] GetCustomSerializedCombinedElementInfo()
        {
            Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] ret = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[1];
            System.Guid[] guids0 = new System.Guid[1];
            guids0[0] = FactTypeHasRole.RoleCollectionMetaRoleGuid;
            ret[0] = new Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo("FactRoles", guids0);
            return ret;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] IORMCustomSerializedElement.GetCustomSerializedCombinedElementInfo()
        {
            return this.GetCustomSerializedCombinedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedElementInfo()
        {
            return new ORMCustomSerializedElementInfo(null, "Fact", null, ORMCustomSerializedElementWriteStyle.Element, null);
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedElementInfo()
        {
            return this.GetCustomSerializedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo IORMCustomSerializedElement.GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedAttributeInfo(attributeInfo, rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((rolePlayedInfo.Id == NestingEntityTypeHasFactType.NestingTypeMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, null, null, ORMCustomSerializedElementWriteStyle.DontWrite, null);
            }
            if ((rolePlayedInfo.Id == SubjectHasPresentation.PresentationMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, null, null, ORMCustomSerializedElementWriteStyle.DontWrite, null);
            }
            return ORMCustomSerializedElementInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedLinkInfo(rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected void SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
        }
        void IORMCustomSerializedElement.SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
            this.SortCustomSerializedChildRoles(playedMetaRoles);
        }
    }
    /// <summary>
    ///</summary>
    public partial class Role : IORMCustomSerializedElement
    {
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations GetSupportedOperations()
        {
            return (ORMCustomSerializedElementSupportedOperations.CustomSerializedAttributeInfo | ORMCustomSerializedElementSupportedOperations.CustomSerializedLinkInfo);
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementSupportedOperations IORMCustomSerializedElement.GetSupportedOperations()
        {
            return this.GetSupportedOperations();
        }
        /// <summary>
        ///</summary>
        protected bool HasMixedTypedAttributes()
        {
            return false;
        }
        bool IORMCustomSerializedElement.HasMixedTypedAttributes()
        {
            return this.HasMixedTypedAttributes();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] GetCustomSerializedCombinedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedCombinedElementInfo[] IORMCustomSerializedElement.GetCustomSerializedCombinedElementInfo()
        {
            return this.GetCustomSerializedCombinedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedElementInfo()
        {
            throw new System.NotSupportedException();
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedElementInfo()
        {
            return this.GetCustomSerializedElementInfo();
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((attributeInfo.Id == Role.IsMandatoryMetaAttributeGuid))
            {
                return new ORMCustomSerializedAttributeInfo(null, "IsMandatory", null, true, ORMCustomSerializedAttributeWriteStyle.Attribute, null);
            }
            if ((attributeInfo.Id == Role.MultiplicityMetaAttributeGuid))
            {
                return new ORMCustomSerializedAttributeInfo(null, "Multiplicity", null, true, ORMCustomSerializedAttributeWriteStyle.Attribute, null);
            }
            return ORMCustomSerializedAttributeInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedAttributeInfo IORMCustomSerializedElement.GetCustomSerializedAttributeInfo(Microsoft.VisualStudio.Modeling.MetaAttributeInfo attributeInfo, Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedAttributeInfo(attributeInfo, rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            if ((rolePlayedInfo.Id == ConstraintRoleSequenceHasRole.ConstraintRoleSequenceCollectionMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, null, null, ORMCustomSerializedElementWriteStyle.DontWrite, null);
            }
            if ((rolePlayedInfo.Id == ObjectTypePlaysRole.RolePlayerMetaRoleGuid))
            {
                return new ORMCustomSerializedElementInfo(null, "RolePlayer", null, ORMCustomSerializedElementWriteStyle.Element, null);
            }
            return ORMCustomSerializedElementInfo.Default;
        }
        Northface.Tools.ORM.Shell.ORMCustomSerializedElementInfo IORMCustomSerializedElement.GetCustomSerializedLinkInfo(Microsoft.VisualStudio.Modeling.MetaRoleInfo rolePlayedInfo)
        {
            return this.GetCustomSerializedLinkInfo(rolePlayedInfo);
        }
        /// <summary>
        ///</summary>
        protected void SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
        }
        void IORMCustomSerializedElement.SortCustomSerializedChildRoles(MetaRoleInfo[] playedMetaRoles)
        {
            this.SortCustomSerializedChildRoles(playedMetaRoles);
        }
    }
}