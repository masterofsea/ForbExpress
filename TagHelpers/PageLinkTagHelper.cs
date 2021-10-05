using ForbExpress.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ForbExpress.TagHelpers
{
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory UrlHelperFactory { get; }

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            UrlHelperFactory = helperFactory;
        }

        [ViewContext] 
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public PageViewModel PageModel { get; set; }
        public string PageAction { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = UrlHelperFactory.GetUrlHelper(ViewContext);
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.SetAttribute("class", "pagination-custom_outline");

            if (PageModel.HasPreviousPage)
            {
                var firstPageLink = new TagBuilder("a")
                {
                    Attributes =
                    {
                        ["href"] = urlHelper.Action(PageAction, new { page = 1, pageCapacity = PageModel.PageCapacity}),
                        ["class"] = "prev"
                    }
                };

                var firstPageLinkSvg = new TagBuilder("svg")
                {
                    Attributes =
                    {
                        ["xmlns"] = "http://www.w3.org/2000/svg",
                        ["width"] = "24",
                        ["height"] = "24",
                        ["viewBox"] = "0 0 24 24",
                        ["fill"] = "none",
                        ["stroke"] = "currentColor",
                        ["stroke-width"] = "2",
                        ["stroke-linecap"] = "round",
                        ["stroke-linejoin"] = "round",
                        ["class"] = "feather feather-chevron-left"
                    }
                };

                var polyline = new TagBuilder("polyline")
                {
                    Attributes =
                    {
                        ["points"] = "15 18 9 12 15 6"
                    }
                };
                
                firstPageLinkSvg.InnerHtml.AppendHtml(polyline);
                firstPageLink.InnerHtml.AppendHtml(firstPageLinkSvg);
                output.Content.AppendHtml(firstPageLink);
            }

            var listTag = new TagBuilder("ul");
            listTag.AddCssClass("pagination");
            var currentItem = CreateLinkItem(PageModel.CurrentPage, urlHelper);
 
            if (PageModel.HasPreviousPage)
            {
                var prevItem = CreateLinkItem(PageModel.CurrentPage - 1, urlHelper);
                listTag.InnerHtml.AppendHtml(prevItem);
            }
             
            listTag.InnerHtml.AppendHtml(currentItem);
            if (PageModel.HasNextPage)
            {
                var nextItem = CreateLinkItem(PageModel.CurrentPage + 1, urlHelper);
                listTag.InnerHtml.AppendHtml(nextItem);
            }

            output.Content.AppendHtml(listTag);
            
            if (PageModel.HasNextPage)
            {
                var nextPageLink = new TagBuilder("a")
                {
                    Attributes =
                    {
                        ["href"] = urlHelper.Action(PageAction, new { page = PageModel.TotalPages, pageCapacity = PageModel.PageCapacity }),
                        ["class"] = "next"
                    }
                };

                var nextPageLinkSvg = new TagBuilder("svg")
                {
                    Attributes =
                    {
                        ["xmlns"] = "http://www.w3.org/2000/svg",
                        ["width"] = "24",
                        ["height"] = "24",
                        ["viewBox"] = "0 0 24 24",
                        ["fill"] = "none",
                        ["stroke"] = "currentColor",
                        ["stroke-width"] = "2",
                        ["stroke-linecap"] = "round",
                        ["stroke-linejoin"] = "round",
                        ["class"] = "feather feather-chevron-left"
                    }
                };

                var polyline = new TagBuilder("polyline")
                {
                    Attributes =
                    {
                        ["points"] = "9 18 15 12 9 6"
                    }
                };
                
                nextPageLinkSvg.InnerHtml.AppendHtml(polyline);
                nextPageLink.InnerHtml.AppendHtml(nextPageLinkSvg);

                output.Content.AppendHtml(nextPageLink);
            }
        }

        private TagBuilder CreateLinkItem(int pageNumber, IUrlHelper urlHelper)
        {
            var item = new TagBuilder("li");
            var link = new TagBuilder("a");

            if (pageNumber == PageModel.CurrentPage) item.AddCssClass("active");
            else link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber, pageCapacity = PageModel.PageCapacity });


            link.InnerHtml.Append(pageNumber.ToString());
            item.InnerHtml.AppendHtml(link);

            return item;
        }
    }
}