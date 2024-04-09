using CerealAPI.Dto;
using CerealAPI.Models;

namespace CerealAPI.Mappers;

public static class CerealMapper
{
    public static CerealDto ToCerealDto(this Cereal cerealModel)
    {
        return new CerealDto
        {
            name = cerealModel.Name,
            manufacturer = cerealModel.Manufacturer,
            type = cerealModel.Type,
            calories = cerealModel.Calories,
            protein = cerealModel.Protein,
            fat = cerealModel.Fat,
            sodium = cerealModel.Sodium,
            fiber = cerealModel.Fiber,
            carbohydrates = cerealModel.Carbohydrates,
            sugars = cerealModel.Sugars,
            potassium = cerealModel.Potassium,
            vitamins = cerealModel.Vitamins,
            shelf = cerealModel.Shelf,
            weight = cerealModel.Weight,
            cups = cerealModel.Cups,
            rating = cerealModel.Rating
        };
    }

    public static Cereal ToCerealFromDto(this CerealDto cerealDto)
    {
        return new Cereal
        {
            Name = cerealDto.name,
            Manufacturer = cerealDto.manufacturer,
            Type = cerealDto.type,
            Calories = cerealDto.calories,
            Protein = cerealDto.protein,
            Fat = cerealDto.fat,
            Sodium = cerealDto.sodium,
            Fiber = cerealDto.fiber,
            Carbohydrates = cerealDto.carbohydrates,
            Sugars = cerealDto.sugars,
            Potassium = cerealDto.potassium,
            Vitamins = cerealDto.vitamins,
            Shelf = cerealDto.shelf,
            Weight = cerealDto.weight,
            Cups = cerealDto.cups,
            Rating = cerealDto.rating
        };
    }


}