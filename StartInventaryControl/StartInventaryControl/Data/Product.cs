using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace StartInventaryControl.Data
{
    public class Product
    {
        public virtual long ID
        {
            get; set;
        }

        public virtual string Description
        {
            get; set;
        }

        public virtual string Annotation
        {
            get; set;
        }

        public virtual string ImagePath
        {
            get; set;
        }

        public virtual IList<Variation> Variations
        {
            get; set;
        }

        public virtual string GetFullDescription()
        {
            var name = string.Empty;

            //if (this.Model != null)
            //    if (!string.IsNullOrEmpty(this.Model.Name))
            //    {
            //        name += $"{this.Model.Name} - ";
            //    }

            //if (!string.IsNullOrEmpty(this.Gender))
            //    name += $"{this.Gender} - ";

            //if (this.Color != null)
            //    if (!string.IsNullOrEmpty(this.Color.Name))
            //    {
            //        name += $"{this.Color.Name} - ";
            //    }

            //if (!string.IsNullOrEmpty(this.Size))
            //    name += $"{SizeTypes.SizeDescription()} {this.Size} - ";

            return !string.IsNullOrEmpty(name) ? Regex.Replace(name, @"\s?-\s?$", "") : name;
        }

        public virtual string ImageCode
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImagePath))
                {
                    return null;
                }
                return this.ImagePath.Split('#')[0];
            }
        } 

        public override string ToString() => this.Description;

        public virtual bool IsNew => this.ID == 0 ? true : false;

        public virtual bool HasVariations => this.Variations == null || this.Variations.Count == 0 ? false : true;

        public virtual bool HasSpecificVariaton(string gender, string color, string size)
        {
            foreach(var variation in this.Variations)
            {
                if(variation.Gender.Equals(gender) && variation.Color.Equals(color) && variation.Size.Equals(size))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
