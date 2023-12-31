﻿namespace Pathwaze.Shared.Models.Entities;

public class Nutrition : BaseEntity
{
    public Guid Id { get; set; }
    public int Calories { get; set; }
    public int SaturatedFat { get; set; }
    public int TransFat { get; set; }
    public int Cholesterol { get; set; }
    public int Sodium { get; set; }
    public int DietaryFiber { get; set; }
    public int Sugars { get; set; }
    public int Protein { get; set; }
}

