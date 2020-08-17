# SeriesManager

**Point of this little project, _was mainly to be able to watch series or movies with subtitles on your TV._**

I found out that almost every TV out there knows how to add subtitles _(.srt file)_ to a movie _(.mkv, .avi, .mp4, ...etc)_ simply if you create
new folder name it same as the movie file, put the movie file inside alongside with the subtitles, **and rename everything the same**.

I thought, that it's cool, but quite boring to do, if you want to manage series with 7 seasons and 10 episodes in each season..

### How does it work
App itself is very simple and looks like this

<img src="https://github.com/xadam1/SeriesManager/blob/master/resources/main.png">

As you can see, you can select **Series folder** (where the movies are located), **Episode Name List** and **Subtitles** _(.zip)_.
_If you wish to just "manage" the series, without subtitles or additional episode names, you can ommit Episode Name List and Subtitles_.

#### Episode Name List
Episode name list can be easily obtained from google, simply by googling name of the series and season, copying the text and putting it into .txt file

| Google output            |  File created |
:-------------------------:|:-------------------------:
<img src="https://github.com/xadam1/SeriesManager/blob/master/resources/google_ep.png">  |  <img src="https://github.com/xadam1/SeriesManager/blob/master/resources/file_ep.png">


#### Subtitles
You can download subtitles from pretty much anywhere. Just check, that they are matching your videos. **Names of the files of subs don't really matter. _App searches for multiple REGEXes matching the names (such as 3x01, Season 2 Episode 3, S2E3, etc..)_**
| | |
|-|-|
| My subtitle .zip file  |  <img src="https://github.com/xadam1/SeriesManager/blob/master/resources/subs.png"> |

#### DONE
| | |
|-|-|
| When the app is done managing your series, it will pop up a little information pane. | <img src="https://github.com/xadam1/SeriesManager/blob/master/resources/done.png"> |

And the original folder looks similar to this.
| Result (Series Folder)   |  Each Subfolder |
:-------------------------:|:-------------------------:
<img src="https://github.com/xadam1/SeriesManager/blob/master/resources/result_folder.png">  |  <img src="https://github.com/xadam1/SeriesManager/blob/master/resources/result_subfolder.png">

Now you can simply upload to your cloud / flash / whatever and play your series on TV with subs.