﻿/*
 * Created by: Miguel Angel Medina Pérez (miguel.medina.perez@gmail.com)
 * Created: 
 * Comments by: Miguel Angel Medina Pérez (miguel.medina.perez@gmail.com)
 */

using System;
using System.Collections.Generic;
using Fingerprints.Model;

namespace Fingerprints.Parziale2004
{
    [Serializable]
    public class PartialeFeatures
    {
        public List<MinutiaTriplet> MTriplets { get; set; }

        public List<Minutia> Minutiae { get; set; }

        public PartialeFeatures()
        {

        }

        public PartialeFeatures(List<MinutiaTriplet> mtList, List<Minutia> mtiaList)
        {
            Minutiae = mtiaList;
            MTriplets = mtList;
        }

        internal List<MinutiaTripletPair> FindAllSimilar(MinutiaTriplet queryMTp)
        {
            var result = new List<MinutiaTripletPair>();
            for (var j = 0; j < MTriplets.Count; j++)
            {
                var currMTp = MTriplets[j];
                if (queryMTp.Match(currMTp))
                    result.Add(new MinutiaTripletPair
                        {
                            QueryMTp = queryMTp,
                            TemplateMTp = currMTp
                        }
                    );
            }
            return result.Count > 0 ? result : null;
        }
    }
}