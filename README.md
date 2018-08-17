# xamarin-forms-test
プライベートでアプリのプロトタイピングした時に勉強がてら作ったもの
- Xamarin.Formsのお試し
- クライアントC#とサーバーGoとの疎通
- クライアント実装の気持ちを理解するためにMVVMっぽい実装に挑戦

~いろいろ整理中~
→ 一旦整理は完了
  - MVVMっぽくできたとこ
    - TodoPageから[TodoIndexの処理](https://github.com/issuy/xamarin-forms-test/blob/bdc0e7077ba7acb914c47d279f5d220ee19924e9/client/Views/TodoPage.xaml.cs#L26)呼び出して、その最中に[ActivityIndicator](https://github.com/issuy/xamarin-forms-test/blob/bdc0e7077ba7acb914c47d279f5d220ee19924e9/client/Views/TodoPage.xaml#L10)表示したあたり
  - 通信リトライダイアログ
    - 呼び出しの流れ、責務の分割度合い的にはいい感じな気がする
    - ただし[Dialogの初期化](https://github.com/issuy/xamarin-forms-test/blob/bdc0e7077ba7acb914c47d279f5d220ee19924e9/client/Views/TodoPage.xaml.cs#L20-L21)は毎ページこの処理を書くのか？ってなるので共通化すべき
  - [CellViewの共通化](https://github.com/issuy/xamarin-forms-test/tree/master/client/Views/ContentViews/Timeline)
    - Timelineの各要素のコントロールがキモになる気がしてて、そこまで進んでない。中途半端。
    - TimelineViewModelがCellViewModelのリストを持って、各CellViewModelがCellViewにBindされるのが良いのかな？
  - Go & GCP
    - apiとwebをapp.yamlで分割してみた。cmsとかもこんな感じで分けるのかな。

# 環境
- クライアント
  - Xamarin.Forms(Visual Studioで作成したプロジェクトベース
- サーバー
  - GCP

# デプロイ方法
- web: `gcloud app deploy app/web/app.yaml`
- api: `gcloud app deploy app/api/app.yaml`

# TODO
- [x] サーバーコード追加
- [x] クライアントコード追加
- [x] 動作確認
  - iOSシミュレータでの動作確認
  - GCPへのデプロイと疎通確認
