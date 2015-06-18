using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edutor.Web.Api.Models
{
    /// <summary>
    /// Paged data response of {T}
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedDataResponse<T> : IPageLinkContaining
    {
        private List<Link> _links;
        private List<T> _items;

        /// <summary>
        /// Cantidad de páginas en total de la respuesta
        /// </summary>
        public int PageCount { get; set; }

        /// <summary>
        /// Número de página en la que se encuentra actualmente
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Tamaño de la página en la que se encuentra actualmente
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Colección de objetos pertenecientes a la consulta realizada
        /// </summary>
        public List<T> Items
        {
            get { return _items ?? (_items = new List<T>()); }
            set { _items = value; }
        }

        /// <summary>
        /// Enlaces HTTP a recursos relacionados con la consulta
        /// </summary>
        public List<Link> Links
        {
            get { return _links ?? (_links = new List<Link>()); }
            set { _links = value; }
        }

        public void AddLink(Link link)
        {
            Links.Add(link);
        }
    }
}
