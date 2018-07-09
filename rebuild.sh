#!/bin/sh

# build Android library
cd google-cameraview
gradle assembleRelease
cd ..

# copy libraries to the Xamarin project
cp google-cameraview/library/build/outputs/aar/library-release.aar CameraView/Jars/library-release.aar
cp google-cameraview/cameraview-vision/build/outputs/aar/cameraview-vision-release.aar CameraView.Vision/Jars/cameraview-vision-release.aar

# build Xamarin Bindings
nuget restore
msbuild /t:Rebuild /p:Configuration=Release CameraView.Vision/CameraView.Vision.csproj

mkdir -p _builds/CameraView
cp CameraView.Vision/bin/Release/CameraView*.dll _builds/CameraView/
