namespace Core.Models
{
    public class Skill
    {
        public string Name { get; set; }

        public int Rank { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }
        
        public bool IsMax
        {
            get {
                if ((this.Name == "Overall" && this.Level == 2277) || this.Level == 99)
                {
                    return true;
                }

                return false;
            }
        }


        public Skill()
        {

        }

        // Perhaps this shouldn't be a method? Instead a property   
        //public bool IsMax()
        //{
        //    if ((this.Name == "Overall" && this.Level == 2277) || this.Level == 99)
        //    {
        //        return true;
        //    }

        //    return false;
        //}

    }
}
