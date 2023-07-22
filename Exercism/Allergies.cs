using System;
using System.Collections;
using System.Collections.Generic;
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}
public class Allergies
{
    private ICollection<Allergen> allergens;
    public Allergies(int mask)
    {
        allergens = new List<Allergen>();
        foreach(int allergen in Enum.GetValues(typeof(Allergen)))
        {
            if ((mask & allergen) == allergen)
            {
                allergens.Add((Allergen)allergen);
            }
        }
    }
    public bool IsAllergicTo(Allergen allergen)
    {
        return allergens.Contains(allergen);
    }
    public Allergen[] List()
    {
        List<Allergen> allergenList = new List<Allergen>(allergens);
        return allergenList.ToArray();
    }
}