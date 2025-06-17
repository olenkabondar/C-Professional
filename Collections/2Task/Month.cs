namespace _2Task
{
    internal class Month
    {
        public string MonthName { get; set; }
        public int Number { get; set; }
        public int CountDays { get; set; }

        public override string ToString()
        {
            return $"{Number}. {MonthName} - {CountDays} днів";
        }
    }
}
