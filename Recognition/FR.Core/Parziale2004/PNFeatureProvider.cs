/*
 * Created by: Miguel Angel Medina P�rez (miguel.medina.perez@gmail.com)
 * Created: 
 * Comments by: Miguel Angel Medina P�rez (miguel.medina.perez@gmail.com)
 */

using System;

namespace PatternRecognition.FingerprintRecognition.Core.Parziale2004
{
    public class PNFeatureProvider
    {
        private readonly PNFeatureExtractor mTripletsCalculator = new PNFeatureExtractor();

        public MinutiaListProvider MtiaListProvider { get; set; }

        public  PNFeatures Extract(byte[] image)
        {
            try
            {
                var mtiae = MtiaListProvider.Extract(image);
                return mTripletsCalculator.ExtractFeatures(mtiae);
            }
            catch (Exception)
            {
                if (MtiaListProvider == null)
                    throw new InvalidOperationException(
                        "Unable to extract PNFeatures: Unassigned minutia list provider!");
                throw;
            }
        }
    }
}