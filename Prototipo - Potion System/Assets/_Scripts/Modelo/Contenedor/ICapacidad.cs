﻿namespace ItIsNotOnlyMe.PotionSystem
{
    public interface ICapacidad
    {
        public void Agregar();

        public void Reducir();

        public bool Vacio();

        public bool Lleno();
    }
}
