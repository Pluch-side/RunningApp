using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    [MetadataType(typeof(PointOfInterestMetaData))]
    public partial class PointOfInterest
    {

    }

    public class PointOfInterestMetaData
    {
        [RegularExpression(@"^-?\d+(?:[.,]\d+)?$", ErrorMessage = "Chiffre uniquement autorisé (négatif ou positifs)")]
        public string Latitude { get; set; }
        [RegularExpression(@"^-?\d+(?:[.,]\d+)?$", ErrorMessage = "Chiffre uniquement autorisé (négatif ou positifs)")]
        public string Longitude { get; set; }
    }
}
