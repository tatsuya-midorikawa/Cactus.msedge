

[<LiteralAttribute>]
let src = @"[02/09/23 00:28:12.687][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Send][url=https://config.edge.skype.com/config/v1/EdgeUpdate/1.3.169.31?clientId=s:7C19494B-4556-4DCD-BAD3-B41089F41819&appBrandCode_edgeupdate=GGLS&appBrandCode_stable=GGLS&appChannel_edgeupdate=6&appChannel_stable=4&appConsentState_edgeupdate=0&appConsentState_stable=2&appDayOfInstall_edgeupdate=0&appDayOfInstall_stable=0&appInEdgePreview_edgeupdate=false&appInEdgePreview_stable=false&appInstallTimeDiffSec_edgeupdate=0&appInstallTimeDiffSec_stable=0&appLastLaunchTime_edgeupdate=0&appLastLaunchTimeJson_edgeupdate=0&appLastLaunchTime_stable=0&appLastLaunchTimeJson_stable=0&appUpdateCheckIsUpdateDisabled_edgeupdate=false&appUpdateCheckIsUpdateDisabled_stable=false&appVersion_edgeupdate=1.3.169.31&appVersion_stable=106.0.1370.52&hwDiskType=2&hwHasSsse3=true&hwLogicalCpus=1&hwPhysmemory=8&isMsftDomainJoined=false&oemProductManufacturer=Microsoft%20Corporation&oemProductName=Virtual%20Machine&osArch=x64&osIsWIP=false&osPlatform=win&osProductType=4&osVersion=10.0.19041.208&requestCheckPeriodSec=-1&requestDomainJoined=false&requestInstallSource=scheduler&requestIsMachine=true&requestOmahaShellVersion=1.3.169.31&requestOmahaVersion=1.3.169.31][request=][filename=]
[02/09/23 00:28:12.687][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Trying config: priority=0, source=auto, wpad=1, script=]
[02/09/23 00:28:12.687][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Trying request type: winhttp]
[02/09/23 00:28:12.687][MicrosoftEdgeUpdate:msedgeupdate][4480:6212][WinHttp status callback][03025AE8][handle=0304C670][request error][API: 5, Error: 0x2ee7]
[02/09/23 00:28:12.687][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Trying config: priority=0, source=direct, direct connection]
[02/09/23 00:28:12.687][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Trying request type: winhttp]
[02/09/23 00:28:12.703][MicrosoftEdgeUpdate:msedgeupdate][4480:3304][WinHttp status callback][0308B348][handle=03088598][request error][API: 5, Error: 0x2ee7]
[02/09/23 00:28:12.703][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Send response received][result 0x80040801][status code 0][]
[02/09/23 00:28:12.703][MicrosoftEdgeUpdate:msedgeupdate][4928:5972][Update all apps process finished][0x80040801]
[02/09/23 00:28:12.843][MicrosoftEdgeUpdate:msedgeupdate][4928:5972][GoopdateImpl::HandleError][0x80040801][1]
[02/09/23 00:28:13.192][MicrosoftEdgeUpdate:msedgeupdate][4928:5972][DllEntry exit][0x00000000]
[02/09/23 00:28:19.942][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][detected configurations][
priority=0, source=auto, wpad=1, script=
priority=0, source=direct, direct connection
]
[02/09/23 00:28:19.942][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Send][url=https://config.edge.skype.com/config/v1/EdgeUpdate/1.3.169.31?clientId=s:7C19494B-4556-4DCD-BAD3-B41089F41819&appBrandCode_edgeupdate=GGLS&appBrandCode_stable=GGLS&appChannel_edgeupdate=6&appChannel_stable=4&appConsentState_edgeupdate=0&appConsentState_stable=2&appDayOfInstall_edgeupdate=0&appDayOfInstall_stable=0&appInEdgePreview_edgeupdate=false&appInEdgePreview_stable=false&appInstallTimeDiffSec_edgeupdate=0&appInstallTimeDiffSec_stable=0&appLastLaunchTime_edgeupdate=0&appLastLaunchTimeJson_edgeupdate=0&appLastLaunchTime_stable=0&appLastLaunchTimeJson_stable=0&appUpdateCheckIsUpdateDisabled_edgeupdate=false&appUpdateCheckIsUpdateDisabled_stable=false&appVersion_edgeupdate=1.3.169.31&appVersion_stable=106.0.1370.52&hwDiskType=2&hwHasSsse3=true&hwLogicalCpus=1&hwPhysmemory=8&isMsftDomainJoined=false&oemProductManufacturer=Microsoft%20Corporation&oemProductName=Virtual%20Machine&osArch=x64&osIsWIP=false&osPlatform=win&osProductType=4&osVersion=10.0.19041.208&requestCheckPeriodSec=-1&requestDomainJoined=false&requestInstallSource=scheduler&requestIsMachine=true&requestOmahaShellVersion=1.3.169.31&requestOmahaVersion=1.3.169.31][request=][filename=]
[02/09/23 00:28:19.942][MicrosoftEdgeUpdate:msedgeupdate][4480:5548][Trying config: priority=0, source=auto, wpad=1, script=]
"

let parse (str: string) =
  let xs = str.Split("\r\n")
  let len = xs.Length
  let acc = Array.zeroCreate len
  let mutable i = 0
  xs |> Array.iter (fun x ->
    acc[i] <- acc[i] + x
    if x.EndsWith(']') then i <- i + 1
  )
  acc |> Array.truncate i
  
@"0]
1]
2]
3
4
5]"
|> parse
|> printfn "%A"

System.Console.ReadKey() |> ignore