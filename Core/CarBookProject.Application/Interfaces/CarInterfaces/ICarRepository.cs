﻿using CarBookProject.Domain.Entities;

namespace CarBookProject.Application.Interfaces.CarInterfaces;

public interface ICarRepository
{
    List<Car> GetCarListWithBrands();
}
