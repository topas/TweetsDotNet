
function Generate-NuSpecFile
{
param(
	[string]$version,
	[string]$file = $(throw "file is a required parameter.")
)
  $nuspec = "<?xml version=""1.0""?>
<package>
  <metadata>
    <id>TweetsDotNet</id>
    <version>$version</version>
    <authors>Tomáš Pastorek</authors>
    <licenseUrl>https://github.com/topas/TweetsDotNet/blob/master/LICENSE</licenseUrl>
    <projectUrl>http://topas.github.com/TweetsDotNet/</projectUrl>
    <requireLicenseAcceptance>false</requireLicenseAcceptance>
    <description>Tweets.NET is very simple .NET library for reading public timeline of specified twitter user.</description>
    <summary>Tweets.NET is very simple .NET library for reading public timeline of specified twitter user.</summary>
    <language>en-US</language>
	  <dependencies>
    </dependencies>
  </metadata>
</package>
"

	$dir = [System.IO.Path]::GetDirectoryName($file)
	if ([System.IO.Directory]::Exists($dir) -eq $false)
	{
		Write-Host "Creating directory $dir"
		[System.IO.Directory]::CreateDirectory($dir)
	}
	Write-Host "Generating nuspec file: $file"
	Write-Output $nuspec > $file
}