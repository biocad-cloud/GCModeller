library(tools) 
library(Cairo)

#########################################################
### A) Installing and loading required packages
#########################################################

if (!require("gplots")) {
	install.packages("gplots", dependencies = TRUE)
	library(gplots)
}
if (!require("RColorBrewer")) {
	install.packages("RColorBrewer", dependencies = TRUE)
	library(RColorBrewer)
}

### 这个脚本比较适合蛋白比较少的，会显示出基因的label
### 所输入的数据文件的要求：
### 1. 第一列数据为基因的编号
### 2. 其他的剩余的数据的列都是基因的表达量或者实验间的logFC值
plotDEPs <- function(csv, size = c(5*300, 5*300), colorsPalette = c("darkblue", "green", "red"), title = NA) {

	#########################################################
	### B) Reading in data and transform it into matrix format
	#########################################################

	data               <- read.csv(csv, comment.char="#")
	rnames             <- data[,1]                          # assign labels in column 1 to "rnames"
	mat_data           <- data.matrix(data[,2:ncol(data)])  # transform column 2-5 into a matrix
	rownames(mat_data) <- rnames                            # assign row names

	#########################################################
	### C) Customizing and plotting the heat map
	#########################################################

	# creates a own color palette from red to green
	my_palette <- colorRampPalette(colorsPalette)(n = 20)

	# (optional) defines the color breaks manually for a "skewed" color transition
	# col_breaks = c(
	#   seq(-1,0,length=100),               # for red
	#   seq(0.01,0.8,length=100),           # for yellow
	#   seq(0.81,1,length=100))             # for green
	
	# 在这里是根据文件名解析出其所在的文件夹，用来在相同的文件夹之中保存所绘制的heatmap图像
	DIR <- dirname(csv)
	DIR <- paste(DIR, file_path_sans_ext(basename(csv)), sep="/")
  
	# creates a 5 x 5 inch image
	png(paste(DIR, "heatmap.png", sep="-"),    # create PNG for the heat map        
		width     = size[0],                   # 5 x 300 pixels
		height    = size[1],
		res       = 300,                       # 300 pixels per inch
		pointsize = 8)                         # smaller font size

	heatmap.2(mat_data,
			  main         = title,            # heat map title
			  notecol      = "black",          # change font color of cell labels to black
			  density.info = "none",           # turns off density plot inside color legend
			  trace        = "none",           # turns off trace lines inside the heat map
			  margins      = c(4, 3),          # widens margins around plot
			  lwid         = c(1.5, 2),
			  lhei         = c(0.4, 2),
			  col          = my_palette,       # use on color palette defined earlier
			  cexRow       = 0.35,
			  # breaks     = col_breaks,       # enable color transition at specified limits
			  dendrogram   = "row",            # only draw a row dendrogram
			  Colv         = "NA")             # turn off column clustering

	dev.off()                                  # close the PNG device
}