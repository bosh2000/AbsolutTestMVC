using AbsolutTestMVC.Models;
using AbsolutTestMVC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace AbsolutTestMVC.Infrastructure
{
    /// <summary>
    /// Класс реализующий хелпер для вывода номеров страниц.
    /// </summary>
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;
        private readonly AbsolutTestSetting _setting;

        public PageLinkTagHelper(
            IUrlHelperFactory helperFactory,
            IOptions<AbsolutTestSetting> setting
            )
        {
            urlHelperFactory = helperFactory;
            _setting = setting.Value;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }
        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            AppendLinkToHtml(urlHelper, result, 1);
            AppendDotTOHtml(result);
            int startLink = 2;
            if (PageModel.CurrentPage > _setting.LinkCount-1)
            { startLink = PageModel.CurrentPage - (_setting.LinkCount / 2); }
            
            for (int i = 0; i < _setting.LinkCount; i++)
            {
                AppendLinkToHtml(urlHelper, result, startLink);
                startLink++;
            }
            AppendDotTOHtml(result);
            AppendLinkToHtml(urlHelper, result, PageModel.TotalPages);

            output.Content.AppendHtml(result.InnerHtml);
        }
        private void AppendDotTOHtml(TagBuilder result)
        {
            TagBuilder tag = new TagBuilder("span");
            tag.InnerHtml.Append("...");
            result.InnerHtml.AppendHtml(tag);
        }
        private void AppendLinkToHtml(IUrlHelper urlHelper, TagBuilder result, int i)
        {
            TagBuilder tag = new TagBuilder("a");
            PageUrlValues["productPage"] = i;
            tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);
            if (PageClassesEnabled)
            {
                tag.AddCssClass(PageClass);
                tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
            }
            tag.InnerHtml.Append(i.ToString());
            result.InnerHtml.AppendHtml(tag);
        }
    }
}