/// <reference path="../../../R-sharp/studio/RMessage.ts" />

namespace RWeb.shell {

    const url: string = "http://127.0.0.1:7452/exec";

    export function handle_command(command: string) {
        $ts.post(url, { script: command }, function (data: any) {
            let result: RInvoke = data;

            if (result.code == 0) {
                if (result.content_type.startsWith("text/html")) {
                    console.log(`<code>${base64_decode(result.info)}</code>`).classList.add("result");
                } else {
                    console.log($ts("<img>", { src: result.info })).classList.add("result");
                }
            } else {
                console.error(result.info);
            }

            if (!isNullOrEmpty(result.warnings)) {
                console.warn("<h3>with additional warning message:</h3>");

                for (let warn of result.warnings) {
                    console.warn($from(warn.environmentStack).Select(a => a.Method.Method).JoinBy(" -> "));

                    for (let i = 0; i < warn.message.length; i++) {
                        console.warn(`${i}. ${warn.message[i]}`);
                    }

                    console.warn("");
                }
            }
        });
    };
}