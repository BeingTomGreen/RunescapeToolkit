
using Core.Enums;

namespace Core.Models
{
    public class Activity
    {
        public ActivityName ActivityName { get; private set; }

        private int _rank;

        public int Rank
        {
            get
            {
                if (_rank < 0)
                    return 0;

                return _rank;
            }
            private set { _rank = value; }
        }

        private int _number;

        public int Number
        {
            get {
                if (_number < 0)
                    return 0;

                return _number;
            }
            private set { _number = value; }
        }

        public Activity(ActivityName activity, int rank, int number)
        {
            this.ActivityName = activity;
            this.Rank = rank;
            this.Number = number;
        }

    }
}
