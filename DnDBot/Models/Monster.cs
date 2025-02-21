namespace DnDBot.Model;

public class Action
    {
        public string name { get; set; }
        public string desc { get; set; }
        public int attack_bonus { get; set; }
        public List<Damage> damage { get; set; }
        public List<object> actions { get; set; }
    }

    public class ArmorClass
    {
        public string type { get; set; }
        public int value { get; set; }
    }

    public class ConditionImmunity
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Damage
    {
        public DamageType damage_type { get; set; }
        public string damage_dice { get; set; }
    }

    public class DamageType
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Proficiency
    {
        public int value { get; set; }
        public Proficiency proficiency { get; set; }
    }

    public class Proficiency2
    {
        public string index { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Monster
    {
        public string name { get; set; }
        public string size { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string alignment { get; set; }
        public List<ArmorClass> armor_class { get; set; }
        public int hit_points { get; set; }
        public string hit_dice { get; set; }
        public string hit_points_roll { get; set; }
        public Speed speed { get; set; }
        public int strength { get; set; }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int intelligence { get; set; }
        public int wisdom { get; set; }
        public int charisma { get; set; }
        public List<Proficiency> proficiencies { get; set; }
        public List<object> damage_vulnerabilities { get; set; }
        public List<object> damage_resistances { get; set; }
        public List<string> damage_immunities { get; set; }
        public List<ConditionImmunity> condition_immunities { get; set; }
        public Senses senses { get; set; }
        public string languages { get; set; }
        public int challenge_rating { get; set; }
        public int proficiency_bonus { get; set; }
        public int xp { get; set; }
        public List<SpecialAbility> special_abilities { get; set; }
        public List<Action> actions { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public DateTime updated_at { get; set; }
        public List<object> legendary_actions { get; set; }

        public override string ToString()
        {
            var strSpeed = toStrSpeed();
            
            return $"## {name}\n" +
                   $"**AC**: {armor_class[0].value}\n" +
                   $"**HP**: {hit_points} ({hit_dice})\n" +
                   $"{strSpeed}\n" +
                   $"";
        }

        private string toStrSpeed()
        {
            List<string> typeSpeed = new ();
            
            if (String.IsNullOrEmpty(speed.walk))
                typeSpeed.Add($"Walk: {speed.walk}");
            
            if (String.IsNullOrEmpty(speed.burrow))
                typeSpeed.Add($"Burrow: {speed.burrow}");
            
            if (String.IsNullOrEmpty(speed.swim))
                typeSpeed.Add($"Swim: {speed.swim}");
            
            if (String.IsNullOrEmpty(speed.climb))
                typeSpeed.Add($"Climb: {speed.climb}");
            
            if (String.IsNullOrEmpty(speed.fly))
                typeSpeed.Add($"Fly: {speed.fly}");
            
            return "**Speed: **" +  String.Join(", ", typeSpeed);
        }
    }

    public class Senses
    {
        public string darkvision { get; set; }
        public int passive_perception { get; set; }
    }

    public class SpecialAbility
    {
        public string name { get; set; }
        public string desc { get; set; }
    }

    public class Speed
    {
        public string? walk { get; set; }
        public string? burrow { get; set; }
        public string? climb { get; set; }
        public string? fly { get; set; }
        public string? swim { get; set; }
    }
