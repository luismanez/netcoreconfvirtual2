# netCore Conference Virtual 2 (3 October 2020)
Materials from my session [__Azure AD MFA + Conditional Access for Developers__](https://virtual-netcoreconf-2.sessionize.com/session/209572) for the netCoreConf 2 Virtual 2020.

## Deploy
Update AppSettings.json with your Azure AD Apps values (ClientId, Secret...)

## EF Core migrations cheatsheet

__Add Migration__
dotnet ef migrations add InitialCreate --project  ./src/Delos.Westworld.Infrastructure --startup-project ./src/Delos.Westworld.EngineeringApi

__Update Database__
dotnet ef database update --project  ./src/Delos.Westworld.Infrastructure --startup-project ./src/Delos.Westworld.EngineeringApi

## Conditional Access issue

This is the response from Azure AD when an API that doesn´t require MFA, calls a downstream API that enforces MFA

```json
{
  "error": "invalid_grant",
  "error_description": "AADSTS50076: Due to a configuration change made by your administrator, or because you moved to a new location, you must use multi-factor authentication to access 'api://f7c3d572-14e2-48a5-be83-c5efef92c0f8'.\r\nTrace ID: 7fd52bab-1e43-40ef-9691-6b3cc9476f00\r\nCorrelation ID: 2b3e6298-1772-454f-b8e7-24f39a27b6fa\r\nTimestamp: 2020-09-24 07:12:27Z",
  "error_codes": [50076],
  "timestamp": "2020-09-24 07:12:27Z",
  "trace_id": "7fd52bab-1e43-40ef-9691-6b3cc9476f00",
  "correlation_id": "2b3e6298-1772-454f-b8e7-24f39a27b6fa",
  "error_uri": "https://login.microsoftonline.com/error?code=50076",
  "suberror": "basic_action",
  "claims": {
    "access_token": {
      "capolids": {
        "essential": true,
        "values": ["25360aa2-xxxx-xxxx-xxxx-bfed5b5c17c5"]
      }
    }
  }
}
```

The values in the "capolids" node are the Conditional Access policies IDs. You can check the IDs in the Azure AD portal. i.e:
https://portal.azure.com/#blade/Microsoft_AAD_IAM/PolicyBlade/policyId/25360aa2-xxxx-xxxx-xxxx-bfed5b5c17c5/appId//policyName/