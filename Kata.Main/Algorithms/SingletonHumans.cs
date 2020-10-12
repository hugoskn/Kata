using System;

namespace Kata.Main.Algorithms
{
    public sealed class Adam : Male 
    {
        private static Adam _AdamInstance;
        private Adam() : base() { }
        private Adam(string name, Female mother, Male father) : base(name, mother, father) { }

        public static Adam GetInstance()
        {
            if (_AdamInstance == null)
            {
                _AdamInstance = new Adam { Name = "Adam" };
            }
            return _AdamInstance;
        }
    }
    public sealed class Eve : Female 
    {
        private static Eve _EveInstance;
        private Eve() : base() { }
        private Eve(string name, Female eve, Male adam) : base(name, eve, adam) { }
        public static Eve GetInstance(Human human)
        {
            if (human == null)
            {
                throw new ArgumentNullException();
            }

            if (_EveInstance == null)
            {
                _EveInstance = new Eve { Name = "Eve" }; ;
            }
            return _EveInstance;
        }
    }
    public class Male : Human
    {
        protected Male() { }
        public Male(string name, Female mother, Male father) : base(name, mother, father) { }

    }
    public class Female : Human
    {
        protected Female() { }
        public Female(string name, Female mother, Male father) : base(name, mother, father) { }
    }
    public abstract class Human 
    {
        protected Human() { }
        public Human(string name, Female mother, Male father)
        {
            if (mother == null || father == null)
            {
                throw new ArgumentNullException();
            }
            Name = name;
            Father = father;
            Mother = mother;
        }
        public string Name { get; set; }        
        public Male Father { get; set; }
        public Female Mother { get; set; }
    }
}
