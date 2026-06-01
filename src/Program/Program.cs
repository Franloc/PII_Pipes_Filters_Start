using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;
using Ucu.Poo.Twitter;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial4 = new PipeSerial(new FilterTwitter("resultado.jpg"), pipeNull); // Publica en twitter
            PipeSerial pipeSave = new PipeSerial(new FilterSave("resultado.jpg"), pipeSerial4); // Guarda la imagen de Luke con el filtro aplicado previamente
            PipeSerial pipeSerial3True = new PipeSerial(new FilterGreyscale(), pipeSave); // Si reconoció que tiene cara, le aplica un filtro de grises y lo manda a pipeSave
            PipeSerial pipeSerial3False = new PipeSerial(new FilterNegative(), pipeSave); // Si reconoció que no tiene cara, le aplica un filtro negativo y lo manda a pipeSave
            PipeIf pipeIf = new PipeIf(pipeSerial3False, pipeSerial3True, new FilterCognitive("luke.jpg")); // Aplico el filtro de reconocimiento facial a luke.jpg

            PipeNull pipeNullBeer = new PipeNull();
            PipeSerial pipeSerialBeerfalse = new PipeSerial(new FilterTwitter("Beer1.jpg"), pipeNullBeer); // Si no reconoció cara, la publica en twitter
            PipeSerial pipeSerialBeertrue = new PipeSerial(new FilterNegative(), pipeNullBeer); // Si reconoció una cara, le aplica el filtro de negativo
            PipeIf PipeIfBeer = new PipeIf(pipeSerialBeerfalse, pipeSerialBeertrue, new FilterCognitive("Beer1.jpg")); // Aplica el filtro de reconocimiento a la cerveza
            PipeSerial PipeSerialBeer1 = new PipeSerial(new FilterSave("Beer1.jpg"), PipeIfBeer); // Guarda la imagen como Beer1 y la manda a la pipe condicional

            PictureProvider provider = new PictureProvider();
            IPicture picture_luke = provider.GetPicture("luke.jpg");
            IPicture picture_beer = provider.GetPicture("beer.jpg");
            pipeIf.Send(picture_luke);
            PipeSerialBeer1.Send(picture_beer);
        }
    }
}
