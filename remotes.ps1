("tkmagesh","lancehilliard","jleigh","allenchi","ilirlako","mikethibault","jeyapradeep","nm95ab","afrofish") | foreach-object{
    git remote add $_ "git://github.com/$_/nbdn_prep.git"
}
