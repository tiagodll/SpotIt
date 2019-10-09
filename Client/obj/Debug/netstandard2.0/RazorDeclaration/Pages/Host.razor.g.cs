#pragma checksum "C:\tiago\blazor\SpotIt\Client\Pages\Host.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "717b2afc2fc86da614840d3dd04c2f197ff6fc8a"
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
#line 3 "C:\tiago\blazor\SpotIt\Client\Pages\Host.razor"
using SpotIt.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.RouteAttribute("/host")]
    [Microsoft.AspNetCore.Components.RouteAttribute("/host/{gameId}")]
    public class Host : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#line 29 "C:\tiago\blazor\SpotIt\Client\Pages\Host.razor"
       
    [Parameter]
    public string gameId { get; set; }

    Game game;
    string GameUrl => $"{NavigationManager.BaseUri}play/{game.Id}";

    protected override async Task OnInitializedAsync()
    {
        if (string.IsNullOrWhiteSpace(gameId))
        {
            game = new Game();
            await Http.SendJsonAsync(HttpMethod.Post, "/api/game", this.game);
            gameId = this.game.Id;
            Console.WriteLine($"play/{gameId}");
            NavigationManager.NavigateTo($"host/{gameId}");
        }
        LoadGame(gameId);
    }

    protected async Task LoadGame(string gameId)
    {
        if (!string.IsNullOrWhiteSpace(gameId))
        {
            Console.WriteLine($"loading game {gameId}");
            this.game = await Http.GetJsonAsync<Game>($"api/game/{gameId}");
            StateHasChanged();
            Console.WriteLine($"game {game.Id} loaded");
        }
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
