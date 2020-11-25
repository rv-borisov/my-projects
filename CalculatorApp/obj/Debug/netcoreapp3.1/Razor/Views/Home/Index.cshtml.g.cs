#pragma checksum "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "20a89f805b362d712009e025ac467b51f7f81743"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\_ViewImports.cshtml"
using CalculatorApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\_ViewImports.cshtml"
using CalculatorApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"20a89f805b362d712009e025ac467b51f7f81743", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8a98f052d04467846782e7730787af5c169d559d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CalculatorApp.Models.Operation>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("calc"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Калькулятор";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a89f805b362d712009e025ac467b51f7f817434111", async() => {
                WriteLiteral("\r\n    <title>Калькулятор</title>\r\n    <style>\r\n        input[type=\"button\"] {\r\n            width: 75px;\r\n            height: 50px;\r\n        }\r\n    </style>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a89f805b362d712009e025ac467b51f7f817435248", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "20a89f805b362d712009e025ac467b51f7f817435510", async() => {
                    WriteLiteral(@"
        <h3>Калькулятор</h3>
        <table>
            <tr>
                <td colspan=""5""><input id=""display"" type=""text"" name=""display"" placeholder=""Результат"" style=""width: 386px; height: 50px; margin-bottom: -3px""></td>
            </tr>
            <tr>
                <td colspan=""5""><input id=""input"" type=""text"" name=""input"" placeholder=""Пример: 4/2+3*sin(30)+4*((-2)^3+3/4)"" ");
                    WriteLiteral(@" style=""width: 386px; height: 50px""></td>
            </tr>
            <tr>
                <td><input type=""button"" class=""btPowFunc"" value=""x^(1/n)"" onclick=""ButtonPowClick(this)""></td>
                <td><input type=""button"" class=""btPowFunc"" value=""x^(n)"" onclick=""ButtonPowClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""Pi"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""e"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""/"" onclick=""ButtonNumberClick(this)""></td>
            </tr>
            <tr>
                <td><input type=""button"" class=""btFunc"" value=""sin"" onclick=""ButtonFunctionClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""7"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""8"" onclick=""ButtonNumberClick(this)""></td>
                <td><input");
                    WriteLiteral(@" type=""button"" class=""btNumber"" value=""9"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""*"" onclick=""ButtonNumberClick(this)""></td>
            </tr>
            <tr>
                <td><input type=""button"" class=""btFunc"" value=""cos"" onclick=""ButtonFunctionClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""4"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""5"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""6"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""-"" onclick=""ButtonNumberClick(this)""></td>
            </tr>
            <tr>
                <td><input type=""button"" class=""btFunc"" value=""tg"" onclick=""ButtonFunctionClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""1"" onclick=""ButtonNumberClick(this)""");
                    WriteLiteral(@"></td>
                <td><input type=""button"" class=""btNumber"" value=""2"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""3"" onclick=""ButtonNumberClick(this)""></td>
                <td><input type=""button"" class=""btNumber"" value=""+"" onclick=""ButtonNumberClick(this)""></td>
            </tr>
            <tr>
                <td><input type=""button"" class=""btFunc"" value=""ctg"" onclick=""ButtonFunctionClick(this)""></td>
                <td colspan=""2""><input type=""button"" value=""0"" onclick=""calc.input.value +='0'"" style=""width: 153px; height: 50px""></td>
                <td><input type=""button"" value=""."" onclick=""calc.input.value +='.'""></td>
                <td><input type=""button"" value=""="" onclick=""Send()""></td>
            </tr>
            <tr>
                <td colspan=""3""><input id=""btTranslate"" type=""button"" value=""Перевод из одной СС в другую"" disabled style=""width: 230px; height: 50px""></td>
                <td><input type=""button"" v");
                    WriteLiteral(@"alue=""С"" onclick=""calc.input.value = ''""></td>
                <td><input type=""button"" value=""<-"" onclick=""DeleteLast()""></td>
            </tr>
        </table>
        <table>
            <tr>
                <td>История вычислений</td>
            </tr>
");
#nullable restore
#line 72 "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\Home\Index.cshtml"
             foreach (var Operations in Model)
            {

#line default
#line hidden
#nullable disable
                    WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 75 "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\Home\Index.cshtml"
                   Write(Operations.Expression);

#line default
#line hidden
#nullable disable
                    WriteLiteral("=");
#nullable restore
#line 75 "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\Home\Index.cshtml"
                                          Write(Operations.Result);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 77 "C:\Users\romka\source\repos\my-projects\CalculatorApp\Views\Home\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                    WriteLiteral("        </table>\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>


<script type=""text/javascript"">
    let input = document.getElementById(""input"");
    document.addEventListener('keypress', function (e) {
        if (e.code == 'Enter') {
            e.preventDefault();
            Send();
        }
    });

    function ButtonNumberClick(e) {
        input.value += e.value;
        input.focus();
    }
    function ButtonFunctionClick(e) {
        input.value += e.value + ""("";
        input.focus();
    }
    function ButtonPowClick(e) {
        var b = e.value.slice(0, -2);
        b = b.slice(1);
        input.value += b;
        input.focus();
    }

    function Send() {
        let display = document.getElementById(""display"");
        $.get({
            url: '/Home/Calculate/',
            data: { input: input.value },
            dataType: 'json',
            success: function (data) {
                display.value = data.result;
                input.value = data.edited;
            }
        })
        /*$.post({
 ");
            WriteLiteral(@"           url: 'Home/Calculate',
            data: { input: input.value, result: display.value },
            success: function () {
            }
        })*/
    }
    function DeleteLast (){
        input.value = input.value.substring(0, input.value.length - 1);
    }

    //function checkKey(key) {
    //    return (key >= '0' && key <= '9') || key == '+' || key == '-' || key == '*' || key == '/' || key == '(' || key == ')' ||
    //        key == '.' || key == ',' || key == 'ArrowLeft' || key == 'ArrowRight' || key == 'Delete' || key == 'Backspace' || key == 'Enter';
    //}

    /*document.addEventListener('keydown', function (e) {
        if (input != document.activeElement && e.code == 'Backspace') {
            DeleteLast();
        }
    });*/
    /*if (input != document.activeElement && ((e.key >= '0' && e.key <= '9') || e.key == '+' || e.key == '-' ||
            e.key == '*' || e.key == '/' || e.key == '(' || e.key == ')' || e.key == '.' || e.key == ',')) {
            inpu");
            WriteLiteral("t.value += e.key;\r\n        }\r\n        else*/\r\n</script>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CalculatorApp.Models.Operation>> Html { get; private set; }
    }
}
#pragma warning restore 1591
