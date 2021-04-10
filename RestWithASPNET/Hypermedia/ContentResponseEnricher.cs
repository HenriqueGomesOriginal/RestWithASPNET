using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using RestWithASPNET.Hypermedia.Abstract;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithASPNET.Hypermedia
{
    public abstract class ContentResponseEnricher<Template> : IResponseEnricher where Template : ISupportsHyperMedia
    {
        public ContentResponseEnricher()
        {

        }
        public virtual bool CanEnrich(Type contentType)
        {
            return contentType == typeof(Template) || contentType == typeof(List<Template>);
        }

        protected abstract Task EnrichModel(Template content, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult okObjectResult)
            {
                return CanEnrich(okObjectResult.Value.GetType());
            }
            return false;
        }
        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            if (response.Result is OkObjectResult okObjectResult)
            { 
                if(okObjectResult.Value is Template model)
                {
                    await EnrichModel(model, urlHelper);
                }
                else if (okObjectResult.Value is List<Template> collection)
                {
                    ConcurrentBag<Template> bag = new ConcurrentBag<Template>(collection);
                    Parallel.ForEach(bag, (element) =>
                    {
                        EnrichModel(element, urlHelper);
                    });
                }
            }
            await Task.FromResult<object>(null);
        }
    }
}
