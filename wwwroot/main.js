// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import { dotnet } from "./_framework/dotnet.js";

const { setModuleImports, getAssemblyExports, getConfig } = await dotnet
  .withDiagnosticTracing(false)
  .withApplicationArgumentsFromQuery()
  .create();

function drawLine(x1, y1, x2, y2, r, g, b) {
  const canvas = document.getElementById("myCanvas");
  const ctx = canvas.getContext("2d");
  ctx.beginPath();
  ctx.moveTo(x1, y1);
  ctx.lineTo(x2, y2);
  const color = `rgb(${Math.floor(r * 255)}, ${Math.floor(
    g * 255
  )}, ${Math.floor(b * 255)})`;
  ctx.strokeStyle = color;
  ctx.stroke();
}

setModuleImports("main.js", {
  window: {
    location: {
      href: () => globalThis.window.location.href,
    },
  },
  canvas: {
    drawLine,
  },
});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);
const text = exports.Hello.WasmBrowserApp.MyClass.Greeting();
console.log(text);

document.getElementById("out").innerHTML = text;
await dotnet.run();
