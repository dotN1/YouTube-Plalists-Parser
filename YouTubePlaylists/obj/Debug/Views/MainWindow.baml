   M S B A M L   `   `   `  ����K  GYouTubePlaylists, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:YouTubePlaylistsYouTubePlaylists  5   	   !    YouTubePlaylists.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:YouTubePlaylists     5   	     � Title$  Playlist Parser��5   	   $��814.717��6!   $��881.034��62    � WindowStartupLocation$ CenterScreen=�6B   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      �� 5      .+�5   
   ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��5q�6,    � ToolTip$ Enter playlist link��67   $	��500��6U   $��20(�6a   $��Center=�6o   ��6   �� *Link+6o   �� 5      $��Parse��6   $��5q�6%   $
��10,5q�60   $��20(�6?   ��6M   �� *ParseCommand+5      &   System.Windows.Controls.DataGrid  5   
   $��5q�6   $��1��6      AutoGenerateColumns .  ��6+   �� *InformationAboutSong+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Thumbnail��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6<   	   CellTemplate	 5      �� 5      .R�5      �� ��6$   �� 
 �� Path$
 ThumbnailUri�5      5      0  *System.Windows.Controls.DataGridTextColumn  5      $ 	Song name��6%   $	 260 68      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   �� $
 SongName�6h     5      $ Artist name��6%   $	 260 6:    .  6F   �� $
 
ArtistName�6l     5      $ Duration��6%   $	 100 67    .  6C   �� $
 Duration�6g   5!      �� 5"   
   $��Playlist name:��6   $
��Left=�6)   $��136,28.6,0,0q�6D   $��2��6Z   $	��Top=�6g   $��25(�6   �� 5#   
   $
��Left=�6I   $��294,28.6,0,0q�6d   $��2��6z   $	��Top=�6�   $��25(�6�   ��6   �� $#
 InformationAboutPlaylist.Name�6�   �� 5$   
   $��Playlist image��6   $
��Left=�6)   $��57,83.6,0,0q�6D   $��2��6Y   $	��Top=�6f   $��25(�6~   �� 5%   
   $��Playlist description��6   $
��Left=�6/   $��498,78.6,0,0q�6J   $��2��6`   $	��Top=�6m   $��25(�6�   �� 5&   
   $
��Left=�6   $	��173��6+   $��10,125.6,0,0q�68   $��2��6N   $	��Top=�6[   $	��283��6s   ��6   �� $(
 "InformationAboutPlaylist.Thumbnail��� 5'   
   $
��Left=�6   $	��239��6/   $��316,125.6,0,0q�6<   $��2��6S   $
��Wrap=�6`   $	��Top=�6t   $	��528��6�   ��6�   �� $*
 $InformationAboutPlaylist.Description�5(      5)      