// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

import {dotnet} from './dotnet.js'

let number

const {setModuleImports, getAssemblyExports, getConfig} = await dotnet
    .withDiagnosticTracing(false)
    .withApplicationArgumentsFromQuery()
    .create();

setModuleImports('main.js', {number: () => number});

const config = getConfig();
const exports = await getAssemblyExports(config.mainAssemblyName);

document.getElementById('pick').addEventListener('click', () => {
    number = exports.MyClass.PickANumber()
    document.getElementById("number").innerHTML = number
})
document.getElementById('compute-js').addEventListener('click', () => {

    const url = "http://localhost:3000?number=" + number
    fetch(url, {
        method: 'GET',
        headers: {
            'Accept': 'application/json',
        },
    })
        .then(response => response.json())
        .then(response => document.getElementById("hash").innerHTML = response.hash)
})
document.getElementById('compute-wasm').addEventListener('click', () => {
    exports.MyClass.ComputeHash().then(res => document.getElementById("hash2").innerHTML = res)
})

await dotnet.run();