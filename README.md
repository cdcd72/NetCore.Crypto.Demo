# NetCore.Crypto.Demo
> 這個專案專注於實作加解密機制。  
> This project focus on implement encrypt & decrypt mechanism.  

> 練習實作加解密機制於 .NET Core 3.1 上。  
To practice how encrypt & decrypt mechanism implement on .NET Core 3.1.  

> :exclamation: 此範例從 secretsettings.json 取得 key 和 salt 是**不安全**的。 :exclamation:  
:exclamation: This example get key & salt from secretsettings.json **isn't secure**. :exclamation:  

## 運行專案
> 假如你想要直接測試應用程式，可以使用 [Postman](https://www.getpostman.com/) 或其他一些用於模擬 Client-side 行為的應用程式。  

If you want to interactively test the application, you can use [Postman](https://www.getpostman.com/) or any other Http client.

> 透過 Visual Studio 2019 或者利用 `dotnet run` 指令先把專案跑起來。
1. Run the project from Visual Studio 2019 or by typing `dotnet run` in a command window  

> 透過 _Postman_ 製作一個如下所示之 GET 要求  
2. Launch _Postman_ and make a GET request as follows:

```
    GET https://localhost:5001/getdecryptdbsettings HTTP/1.1
    cache-control: no-cache
    Accept: */*
    Host: localhost:5001
    accept-encoding: gzip, deflate, br
    Connection: keep-alive
```

> 便會得到以下 Database 設定資料被解密後的回應：  

returns the following database settings decrypted response:

```
{
  "connectionType":"Oracle",
  "connectionString":"Oracle connection string in here."
}
```

> 製作一個如下所示之 POST 要求   
3. Make a POST request like the following:

```
    POST https://localhost:5001/encrypt HTTP/1.1
    cache-control: no-cache
    Content-Type: application/json
    Accept: */*
    Host: localhost:5001
    accept-encoding: gzip, deflate, br

    HTTP message body:
    { "Text" : "Oracle connection string in here." }
```

> 便會得到以下被加密後的回應：  

returns the following encrypted response:

```
{
    "text": "KlSs6zCs9CTz68vjJWvRTvC6TlpHEKJRWCU+O4QEfTdPru7DqDVMCHxzuhKuZMo+aXl5xq9CxHkkdw9DfT8PeiP7GleUsFPzNDFynRfmIDU="
}
```

> 製作另一個如下所示之 POST 要求   
3. Then make another a POST request like the following:

```
    POST https://localhost:5001/decrypt HTTP/1.1
    cache-control: no-cache
    Content-Type: application/json
    Accept: */*
    Host: localhost:5001
    accept-encoding: gzip, deflate, br

    HTTP message body:
    { "Text" : "KlSs6zCs9CTz68vjJWvRTvC6TlpHEKJRWCU+O4QEfTdPru7DqDVMCHxzuhKuZMo+aXl5xq9CxHkkdw9DfT8PeiP7GleUsFPzNDFynRfmIDU=" }
```

> 便會得到以下被解密後的回應：  

returns the following decrypted response:

```
{
    "text": "Oracle connection string in here."
}
```

## 最後版本
1.0.0.0 (March 31, 2020)

## 記錄
* 1.0.0.0
  * Initial Commit (初次上版)
  
## 參考 github
[ConfiguarationBridgeCrypto](https://github.com/configureappio/ConfiguarationBridgeCrypto) by Steve Collins    

## 參考文章
* English
  * [Hiding Secrets in appsettings.json – Using a Bridge in your ASP.Net Core Configuration (Part 4)](https://stevetalkscode.co.uk/configuration-bridging-part-4)   
