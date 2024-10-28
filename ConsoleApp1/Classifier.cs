public static class Classifier
{
    public static Character ClassifyIndividual(Individual individual)
    {
        // Check if humanoid or not
        if (individual.isHumanoid.HasValue)
        {
            if (individual.isHumanoid.Value)
            {
                if (individual.age.HasValue && individual.age.Value > 5000)
                {
                    return new Elf();
                }
                // Humanoid characters
                if (!string.IsNullOrEmpty(individual.planet))
                {
                    if (individual.planet == "Asgard") return new Asgardian();
                    if (individual.planet == "Earth")
                    {
                        if (individual.age.HasValue)
                        {
                            if (individual.age <= 200) return new Dwarf();

                        }
                        return new Elf(); // Default to Elf for indefinite age
                    }
                    if (individual.planet == "Betelgeuse") return new Betelgeusian();
                }
            }
            else
            {
                // Non-humanoid characters
                if (!string.IsNullOrEmpty(individual.planet))
                {
                    if (individual.planet == "Kashyyyk") return new Wookie();
                    if (individual.planet == "Endor") return new Ewok();
                    if (individual.planet == "Vogsphere") return new Vogon();
                }
            }
        }

        // If humanoid is null, check the planet and age
        if (!string.IsNullOrEmpty(individual.planet))
        {
            if (individual.planet == "Kashyyyk") return new Wookie();
            if (individual.planet == "Endor") return new Ewok();
            if (individual.planet == "Asgard") return new Asgardian();
            if (individual.planet == "Betelgeuse") return new Betelgeusian();
            if (individual.planet == "Vogsphere") return new Vogon();
            if (individual.planet == "Earth")
            {
                if (individual.age.HasValue)
                {
                    if (individual.age <= 200) return new Dwarf();
                    if (individual.age > 5000) return new Elf(); // Specific age condition for Elf
                }
                else if (individual.traits.Contains("SHORT") || individual.traits.Contains("BULKY"))
                {
                    return new Dwarf();
                }
            }
        }

        // Check traits if planet and age are not sufficient for classification
        if (individual.traits != null && individual.traits.Count > 0)
        {
            if (individual.isHumanoid.HasValue)
            {
                if (individual.isHumanoid.Value)
                {
                    if (individual.traits.Contains("SHORT") || individual.traits.Contains("BULKY"))
                        return new Dwarf();
                    else if ((individual.traits.Contains("BLONDE") || individual.traits.Contains("TALL")) && individual.age.HasValue && individual.age.Value <= 5000)
                        return new Asgardian();
                }
                else
                {
                    if (individual.traits.Contains("GREEN") || individual.traits.Contains("BULKY"))
                        return new Vogon();
                }
            }

            if ((individual.traits.Contains("HAIRY") || individual.traits.Contains("TALL")) && individual.age.HasValue && individual.age.Value <= 400) return new Wookie();
            if ((individual.traits.Contains("SHORT") || individual.traits.Contains("HAIRY")) && individual.age.HasValue && individual.age.Value <= 60) return new Ewok();
            if ((individual.traits.Contains("BLONDE") || individual.traits.Contains("TALL")) && individual.age.HasValue && individual.age.Value <= 5000) return new Asgardian();
            if ((individual.traits.Contains("EXTRA_ARMS") || individual.traits.Contains("EXTRA_HEAD")) && individual.age.HasValue) return new Betelgeusian();
            if ((individual.traits.Contains("SHORT") || individual.traits.Contains("BULKY")) && individual.age.HasValue) return new Dwarf();
        }

        return null;
    }
}
