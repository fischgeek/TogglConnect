using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ko
{
    public static class QuickMarkup
    {
        public static IHtmlString Test() => new HtmlString(@"<p>Hello</p>".Trim());
        /// <summary>
        /// Provides markup for a label and a Knockout value.
        /// </summary>
        /// <param name="label">The label to display above the value.</param>
        /// <param name="value">The Knockout binding text value.</param>
        /// <returns>An HTML formatted string.</returns>
        public static IHtmlString DisplayLabelValue(string label, string value) => new HtmlString($@"<b>{label}</b><br /><span data-bind=""text: {value}""></span>".Trim());

        /// <summary>
        /// Provides markup for a label and a Knockout boolean value displayed as a checkmark.
        /// </summary>
        /// <param name="label">The label to display above the value.</param>
        /// <param name="value">The Knockout binding bool value.</param>
        /// <returns>An HTML formatted string.</returns>
        public static IHtmlString DisplayLabelBoolValue(string label, string value) => new HtmlString($@"<b>{label}</b><br /><span class=""glyphicon"" data-bind=""css: {{ 'glyphicon-ok': {value}() == true, 'glyphicon-remove': {value}() == false }}""></span>".Trim());
    }
}
