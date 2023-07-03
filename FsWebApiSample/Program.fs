namespace FsWebApiSample
#nowarn "20"
open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging

module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)

        builder.Services.AddSwaggerGen()

        let app = builder.Build()

        if (app.Environment.IsDevelopment()) then
            app.UseSwagger()
            app.UseSwaggerUI()
            |> ignore

        app.UseHttpsRedirection()

        app.UseAuthorization()

        app.Run()

        exitCode
