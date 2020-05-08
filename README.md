# CameraPlusCFGChange   

CameraPlusCFGChangeは[CameraPlus](https://github.com/Snow1226/CameraPlus)を導入前提としたMODです。    
ゲームシーンとメニューシーンでカメラのコンフィグファイルを切り替えて、それぞれ見せたいカメラを選択できるようするMODです。    
    
    
## インストール
    
1.CameraPlusを導入します  
2.CameraPlusCFGChange.dllをBeat Saberインストール先のPluginsフォルダに入れます  
3.一度ビートセイバーを起動してUserDataフォルダに「CameraPlusCFGChange.ini」を作成します   
4.以下の項目を設定します   
DefaultCamera (メニューシーンで使うカメラのCFGファイルを指定)   
GameCamera (ゲームシーンで使用するカメラフのCFGファイルを指定)   
OutputCamera (書き換える対象カメラのCFGファイルを指定)   
    
［設定例］ 
[Modes]   
DefaultCamera = cfg\cameraplus_menu.cfg   
GameCamera = cfg\cameraplus_game.cfg    
OutputCamera = cameraplus.cfg   
※CameraPlusのUserDataフォルダにcfgフォルダを作成して、置き換え用のファイルを用意しています。   
    
    
## バグ報告 
    
下記にお願いいたします。  
Twitter:[Reiya](https://twitter.com/Reiya__)  
    
    
## ライセンス
    
MIT license
