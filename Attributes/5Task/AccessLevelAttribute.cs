namespace _5Task
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class AccessLevelAttribute : Attribute
    {
        public int Level { get; }

        public AccessLevelAttribute(int level)
        {
            Level = level;
        }
    }
}
