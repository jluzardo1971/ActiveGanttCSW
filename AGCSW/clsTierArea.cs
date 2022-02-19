// ----------------------------------------------------------------------------------------
//                              COPYRIGHT NOTICE
// ----------------------------------------------------------------------------------------
//
// The Source Code Store LLC
// ACTIVEGANTT SCHEDULER COMPONENT FOR C# - ActiveGanttCSW
// WPF Control
// Copyright (c) 2002-2017 The Source Code Store LLC
//
// All Rights Reserved. No parts of this file may be reproduced, modified or transmitted 
// in any form or by any means without the written permission of the author.
//
// ----------------------------------------------------------------------------------------
using System;

namespace AGCSW
{

	public class clsTierArea
	{
        private ActiveGanttCSWCtl mp_oControl;
        public clsTier UpperTier;
        public clsTier MiddleTier;
        public clsTier LowerTier;
        public clsTierFormat TierFormat;
        public clsTierAppearance TierAppearance;
        private clsTimeLine mp_oTimeLine;

        internal clsTierArea(ActiveGanttCSWCtl oControl, clsTimeLine oTimeLine)
        {
            mp_oControl = oControl;
            mp_oTimeLine = oTimeLine;
            UpperTier = new clsTier(mp_oControl, this, E_TIERPOSITION.SP_UPPER);
            MiddleTier = new clsTier(mp_oControl, this, E_TIERPOSITION.SP_MIDDLE);
            LowerTier = new clsTier(mp_oControl, this, E_TIERPOSITION.SP_LOWER);
            TierFormat = new clsTierFormat(mp_oControl);
            TierAppearance = new clsTierAppearance(mp_oControl);
            Clear();
        }

		internal clsTimeLine TimeLine 
		{
			get 
			{
				return mp_oTimeLine;
			}
		}

		public String GetXML()
		{
			clsXML oXML = new clsXML(mp_oControl, "TierArea");
			oXML.InitializeWriter();
			oXML.WriteObject(LowerTier.GetXML());
			oXML.WriteObject(MiddleTier.GetXML());
			oXML.WriteObject(TierAppearance.GetXML());
			oXML.WriteObject(TierFormat.GetXML());
			oXML.WriteObject(UpperTier.GetXML());
			return oXML.GetXML();
		}

		public void SetXML(String sXML)
		{
			clsXML oXML = new clsXML(mp_oControl, "TierArea");
			oXML.SetXML(sXML);
			oXML.InitializeReader();
			LowerTier.SetXML(oXML.ReadObject("LowerTier"));
			MiddleTier.SetXML(oXML.ReadObject("MiddleTier"));
			TierAppearance.SetXML(oXML.ReadObject("TierAppearance"));
			TierFormat.SetXML(oXML.ReadObject("TierFormat"));
			UpperTier.SetXML(oXML.ReadObject("UpperTier"));
		}

        internal void Clear()
        {
            UpperTier.Clear();
            MiddleTier.Clear();
            LowerTier.Clear();
            TierFormat.Clear();
            TierAppearance.Clear();
        }

        internal void Clone(clsTierArea oClone)
        {
            UpperTier.Clone(oClone.UpperTier);
            MiddleTier.Clone(oClone.MiddleTier);
            LowerTier.Clone(oClone.LowerTier);
            TierFormat.Clone(oClone.TierFormat);
            TierAppearance.Clone(oClone.TierAppearance);
        }



	}
}