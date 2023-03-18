# CVE-2023-23397-PoC

C# send only version of [CVE-2023-23397-POC-Powershell](https://github.com/api0cradle/CVE-2023-23397-POC-Powershell) by Oddvar Moe (@oddvarmoe)

Sends email from the address associated with Outlook account.

```
.\CVE_2023_23397.exe --help
CVE_2023_23397 1.0.0.0
Copyright c  2023

  -t, --to         Required. Recipient email address

  -p, --path       Required. UNC Path

  -s, --subject    Message subject ("Testing New Exploit" if blank)

  -b, --body       Message body ("Here's your meeting invite" if blank)

  --help           Display this help screen.

  --version        Display version information.
  ```
