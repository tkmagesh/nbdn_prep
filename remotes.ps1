# If you get this error:
# 
# File R:\repositories\nbdn_prep\remotes.ps1 cannot be loaded because the execution of scripts is disabled on this system.
# 
# This PS command might solve the problem:
# 
# Set-ExecutionPolicy Unrestricted
# 
# And this article explains what you're doing when you execute that command:
# 
# http://www.itexperience.net/2008/07/18/file-cannot-be-loaded-because-the-execution-of-scripts-is-disabled-on-this-system-error-in-powershell/
# 

("developwithpassion", "tkmagesh","lancehilliard","jleigh","allenchi","ilirlako","mikethibault","jeyapradeep","nm95ab","afrofish") | foreach-object{
    git remote add $_ "git://github.com/$_/nbdn_prep.git"
}
