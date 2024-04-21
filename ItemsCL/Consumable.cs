using EntityCL;

namespace ConsumablesCL
{
    public abstract class Consumable
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Amount { get; protected set; }
        public Consumable(string name, string description, int amount) 
        {
            Name = name;
            Description = description;
            Amount = amount;
        }
        public abstract void Effect(Player player);
    }
}
