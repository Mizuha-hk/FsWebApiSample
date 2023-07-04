namespace FsWebApiSample.Endpoints

open System
open System.Runtime.CompilerServices    //[<Extension>]
open Microsoft.AspNetCore.Builder       //MapGroup
open Microsoft.AspNetCore.Routing       //IEndpointRouteBuilder
open Microsoft.AspNetCore.Http          //IResult & TypedResults

[<Extension>]
type SampleEndpoints =
    
    [<Extension>]
    static member public MapSampleEndpoints(routes : IEndpointRouteBuilder) : unit =

        let group = routes.MapGroup("/api/Sample").WithTags("Sample")

        group.MapGet("/", Func<IResult>(fun () -> 
            TypedResults.Ok("Sample")))
            .WithName("SampleGet")
            .WithOpenApi()

        |> ignore