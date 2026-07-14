# .NET on Vercel

A stock `dotnet new webapp` ASP.NET Core Razor Pages app, deployed to Vercel as a container.

## How it works

The only Vercel-specific piece is a [`Dockerfile.vercel`](./Dockerfile.vercel) at the repo
root. Vercel detects it, builds the image on every commit, and runs it on Fluid compute, which
autoscales and scales to zero when idle. The container just serves HTTP on the `PORT` Vercel
provides — [`Program.cs`](./Program.cs) binds `http://0.0.0.0:$PORT` — and TLS is handled at the
edge.

The image uses a multi-stage build: the .NET SDK compiles a release publish, and the app ships
on the minimal `aspnet:10.0-noble-chiseled` runtime (no shell or package manager, runs as a
non-root user).

## Run locally

```bash
dotnet run
```

Then open the printed URL (defaults to `http://localhost:5068`).

To run the container the way Vercel does:

```bash
docker build -f Dockerfile.vercel -t dotnet-on-vercel .
docker run -p 8080:8080 dotnet-on-vercel
```

## Pages

- **Home** — the stock template landing page.
- **Diagnostics** — non-sensitive .NET runtime info (framework, OS, architecture, CPU count).

## Docs

- [Does Vercel support Docker deployments?](https://vercel.com/kb/guide/does-vercel-support-docker-deployments)
- [Run any Dockerfile on Vercel](https://vercel.com/blog/dockerfile-on-vercel)
