﻿using System;
using System.Reflection;

// Common Public License Copyright Notice
// /**************************************************************************\
// * Natural Object-Role Modeling Architect for Visual Studio                 *
// *                                                                          *
// * Copyright © Neumont University. All rights reserved.                     *
// *                                                                          *
// * The use and distribution terms for this software are covered by the      *
// * Common Public License 1.0 (http://opensource.org/licenses/cpl) which     *
// * can be found in the file CPL.txt at the root of this distribution.       *
// * By using this software in any fashion, you are agreeing to be bound by   *
// * the terms of this license.                                               *
// *                                                                          *
// * You must not remove this notice, or any other, from this software.       *
// \**************************************************************************/

namespace ORMSolutions.ORMArchitect.Framework
{
	#region Attach rules to FrameworkDomainModel model
	partial class FrameworkDomainModel
	{
		private static Type[] myCustomDomainModelTypes;
		private static Type[] CustomDomainModelTypes
		{
			get
			{
				Type[] retVal = FrameworkDomainModel.myCustomDomainModelTypes;
				if (retVal == null)
				{
					// No synchronization is needed here.
					// If accessed concurrently, the worst that will happen is the array of Types being created multiple times.
					// This would have a slightly negative impact on performance, but the result would still be correct.
					// Given the low likelihood of this ever happening, the extra overhead of synchronization would outweigh any possible gain from it.
					retVal = new Type[]{
						typeof(DelayValidateElementsClass),
						typeof(TransactionRulesFixupHack)};
					FrameworkDomainModel.myCustomDomainModelTypes = retVal;
					System.Diagnostics.Debug.Assert(Array.IndexOf<Type>(retVal, null) < 0, "One or more rule types failed to resolve. The file and/or package will fail to load.");
				}
				return retVal;
			}
		}
		/// <summary>Generated code to attach <see cref="Microsoft.VisualStudio.Modeling.Rule"/>s to the <see cref="Microsoft.VisualStudio.Modeling.Store"/>.</summary>
		/// <seealso cref="Microsoft.VisualStudio.Modeling.DomainModel.GetCustomDomainModelTypes"/>
		protected override Type[] GetCustomDomainModelTypes()
		{
			if (ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel.InitializingToolboxItems)
			{
				return Type.EmptyTypes;
			}
			Type[] retVal = base.GetCustomDomainModelTypes();
			int baseLength = retVal.Length;
			Type[] customDomainModelTypes = FrameworkDomainModel.CustomDomainModelTypes;
			if (baseLength <= 0)
			{
				return customDomainModelTypes;
			}
			else
			{
				Array.Resize<Type>(ref retVal, baseLength + customDomainModelTypes.Length);
				customDomainModelTypes.CopyTo(retVal, baseLength);
				return retVal;
			}
		}
	}
	#endregion // Attach rules to FrameworkDomainModel model
	#region Auto-rule classes
	#region Rule classes for FrameworkDomainModel
	partial class FrameworkDomainModel
	{
		[Microsoft.VisualStudio.Modeling.RuleOn(typeof(DelayValidateSignal), FireTime=Microsoft.VisualStudio.Modeling.TimeToFire.LocalCommit, Priority=ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel.DelayValidateRulePriority)]
		private sealed class DelayValidateElementsClass : Microsoft.VisualStudio.Modeling.AddRule
		{
			/// <summary>
			/// Provide the following method in class: 
			/// ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel
			/// /// <summary>
			/// /// AddRule: typeof(DelayValidateSignal), FireTime=LocalCommit, Priority=FrameworkDomainModel.DelayValidateRulePriority;
			/// /// </summary>
			/// private static void DelayValidateElements(ElementAddedEventArgs e)
			/// {
			/// }
			/// </summary>
			[System.Diagnostics.DebuggerStepThrough()]
			public override void ElementAdded(Microsoft.VisualStudio.Modeling.ElementAddedEventArgs e)
			{
				ORMSolutions.ORMArchitect.Framework.Diagnostics.TraceUtility.TraceRuleStart(e.ModelElement.Store, "ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel.DelayValidateElements");
				FrameworkDomainModel.DelayValidateElements(e);
				ORMSolutions.ORMArchitect.Framework.Diagnostics.TraceUtility.TraceRuleEnd(e.ModelElement.Store, "ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel.DelayValidateElements");
			}
		}
		[Microsoft.VisualStudio.Modeling.RuleOn(typeof(FrameworkDomainModel))]
		private sealed partial class TransactionRulesFixupHack : Microsoft.VisualStudio.Modeling.TransactionBeginningRule
		{
			/// <summary>
			/// Provide the following method in class: 
			/// ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel
			/// partial class TransactionRulesFixupHack
			/// {
			/// 	/// <summary>
			/// 	/// TransactionBeginningRule: typeof(FrameworkDomainModel)
			/// 	/// </summary>
			/// 	private void ProcessTransactionBeginning(TransactionBeginningEventArgs e)
			/// 	{
			/// 	}
			/// }
			/// </summary>
			[System.Diagnostics.DebuggerStepThrough()]
			public override void TransactionBeginning(Microsoft.VisualStudio.Modeling.TransactionBeginningEventArgs e)
			{
				ORMSolutions.ORMArchitect.Framework.Diagnostics.TraceUtility.TraceRuleStart(e.Transaction.Store, "ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel.TransactionRulesFixupHack");
				this.ProcessTransactionBeginning(e);
				ORMSolutions.ORMArchitect.Framework.Diagnostics.TraceUtility.TraceRuleEnd(e.Transaction.Store, "ORMSolutions.ORMArchitect.Framework.FrameworkDomainModel.TransactionRulesFixupHack");
			}
		}
	}
	#endregion // Rule classes for FrameworkDomainModel
	#endregion // Auto-rule classes
}
