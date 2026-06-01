using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CompAndDel;


namespace CompAndDel.Pipes
{
    public class PipeIf : IPipe
    {
        private IPipe pipeTrue; // La pipe a la que va a enviar la imagen si el resultado del if es true
        public IPipe PipeTrue
        {
            get {return this.pipeTrue;} set {this.pipeTrue = value;}
        }
        private IPipe pipeFalse; // La pipe a la que va a enviar la imagen si el resultado del if es falso
        public IPipe PipeFalse
        {
            get {return this.pipeFalse;} set {this.pipeFalse = value;}
        }
        private IFilter filter; // Filtro que va a aplicar (en este caso, uso el filtro de reconocimiento facial para determinar si hay caras o no en la imagen)
        public IFilter Filter
        {
            get {return this.filter;} set {this.filter = value;}
        }

        public PipeIf(IPipe pipeFalse, IPipe pipeTrue, IFilter filter) 
        {
            this.pipeTrue = pipeTrue;
            this.pipeFalse = pipeFalse;        
            this.filter = filter;
        }
        
        public IPicture Send(IPicture picture)
        {
            picture = filter.Filter(picture);
            if (filter.Result)
            {
                return pipeTrue.Send(picture);
            }
            else return pipeFalse.Send(picture);
        }
    }
}
