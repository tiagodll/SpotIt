#pragma checksum "C:\tiago\blazor\SpotIt\Client\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64cea9e10264c95ca3b6649634ec3ce5ca004b3f"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SpotIt.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\tiago\blazor\SpotIt\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\tiago\blazor\SpotIt\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\tiago\blazor\SpotIt\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 4 "C:\tiago\blazor\SpotIt\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#line 5 "C:\tiago\blazor\SpotIt\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\tiago\blazor\SpotIt\Client\_Imports.razor"
using SpotIt.Client;

#line default
#line hidden
#line 7 "C:\tiago\blazor\SpotIt\Client\_Imports.razor"
using SpotIt.Client.Shared;

#line default
#line hidden
#line 2 "C:\tiago\blazor\SpotIt\Client\Pages\FetchData.razor"
using SpotIt.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 38 "C:\tiago\blazor\SpotIt\Client\Pages\FetchData.razor"
       
    WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await Http.GetJsonAsync<WeatherForecast[]>("WeatherForecast");
    }


#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
