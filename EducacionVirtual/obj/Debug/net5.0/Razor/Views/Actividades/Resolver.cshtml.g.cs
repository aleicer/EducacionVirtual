#pragma checksum "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e27bdfd0f0a6540eac606f2be0e40a63b0244d2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Actividades_Resolver), @"mvc.1.0.view", @"/Views/Actividades/Resolver.cshtml")]
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
#line 1 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\_ViewImports.cshtml"
using EducacionVirtual;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\_ViewImports.cshtml"
using EducacionVirtual.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
using EducacionVirtual.Models.evaluaciones;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e27bdfd0f0a6540eac606f2be0e40a63b0244d2f", @"/Views/Actividades/Resolver.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca98b336c1c4ebdf457b45958b5d48498647eb31", @"/Views/_ViewImports.cshtml")]
    public class Views_Actividades_Resolver : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
  
    ViewData["Title"] = "Resolver";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1>Resolver Actividad</h1>\r\n    <h3>");
#nullable restore
#line 9 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
   Write(ViewBag.mensaje);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n</div>\r\n<div style=\"background: linear-gradient(#a7eaee, #d6e2b8)\"  >\r\n");
#nullable restore
#line 12 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
     using (Html.BeginForm())
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
         foreach (Preguntas item in ViewBag.ListaPreguntas)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <table class=\"table-bordered \">\r\n                <tr class=\"border-2\">\r\n                    <td>");
#nullable restore
#line 18 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ) ");
#nullable restore
#line 18 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
                              Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td class=\"border-3\">\r\n                        <input id=\"Opcion1\" type=\"radio\"");
            BeginWriteAttribute("name", " name=\"", 726, "\"", 746, 1);
#nullable restore
#line 22 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue("", 733, item.Opcion1, 733, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rb\"");
            BeginWriteAttribute("value", " value=\"", 758, "\"", 780, 1);
#nullable restore
#line 22 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue(" ", 766, item.Opcion1, 767, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 22 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
                                                                                                            Write(item.Opcion1);

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        <input id=\"Opcion2\" type=\"radio\"");
            BeginWriteAttribute("name", " name=\"", 856, "\"", 876, 1);
#nullable restore
#line 23 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue("", 863, item.Opcion2, 863, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rb\"");
            BeginWriteAttribute("value", " value=\"", 888, "\"", 910, 1);
#nullable restore
#line 23 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue(" ", 896, item.Opcion2, 897, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 23 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
                                                                                                            Write(item.Opcion2);

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        <input id=\"Opcion3\" type=\"radio\"");
            BeginWriteAttribute("name", " name=\"", 986, "\"", 1006, 1);
#nullable restore
#line 24 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue("", 993, item.Opcion3, 993, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rb\"");
            BeginWriteAttribute("value", " value=\"", 1018, "\"", 1040, 1);
#nullable restore
#line 24 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue(" ", 1026, item.Opcion3, 1027, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 24 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
                                                                                                            Write(item.Opcion3);

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        <input id=\"Opcion4\" type=\"radio\" |");
            BeginWriteAttribute("name", " name=\"", 1118, "\"", 1138, 1);
#nullable restore
#line 25 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue("", 1125, item.Opcion4, 1125, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rb\"");
            BeginWriteAttribute("value", " value=\"", 1150, "\"", 1172, 1);
#nullable restore
#line 25 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue(" ", 1158, item.Opcion4, 1159, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("> ");
#nullable restore
#line 25 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
                                                                                                              Write(item.Opcion4);

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n                        <label");
            BeginWriteAttribute("name", " name=\"", 1222, "\"", 1237, 1);
#nullable restore
#line 26 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
WriteAttributeValue("", 1229, item.Id, 1229, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"rb\" style=\"display:none; color: red; font: bold;\">");
#nullable restore
#line 26 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
                                                                                                   Write(item.Solucion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n                    </td>\r\n                </tr>\r\n            </table>\r\n");
#nullable restore
#line 30 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br />\r\n        <button id=\"but1\" type=\"button\" value=\"submit\" class=\"btn-success\">Enviar</button>\r\n        <label id=\"Ibluseranswer\"></label>\r\n");
#nullable restore
#line 34 "C:\Educacioncasa\EducacionVirtual\EducacionVirtual\Views\Actividades\Resolver.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>



<script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js""></script>
<script>
    $(document).ready(function () {
        $(""#but1"").click(function () {
            $("".rb"").show();
            $("".rb"").attr(""disabled"", true);
        });
    });
");
            WriteLiteral("\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591