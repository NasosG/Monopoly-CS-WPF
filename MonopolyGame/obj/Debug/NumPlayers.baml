   M S B A M L   `   `   `  ����G  CMonopolyGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MonopolyGameMonopolyGame  5   	       MonopolyGame.NumPlayers   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:MonopolyGame     5   	   -   5          � 
ResizeMode$  NoResize=�5   	    � Title$ Select Number Of Players��5	   	   $	��300��6*   $	��450��67   .��5
      � $��	0,223,0,0q�6   .+�5   
   �� $��-13,-118,0.2,0.4q�6   $��backgroundMenu.png��6*   $
��Fill=�6F   �� 5   
   $��Center=�6   $��85��62   $��107,-167,106,0q�6>   $	��Top=�6V   $	��229��6n   .+�5      �� $��14(�6   $
��Bold"�6"   $��
-2,0,-16,0q�64   $��Select number of players:��6H   	� 5      -   5         	�Name$
 Box2��5      $��14(�6(   $��DemiBold"�66   $��4,0,0,0q�6L   $��2��6]    	� 	GroupName$
 nums��6i   6z   	� 5      -   5        $
 Box3��5      $��14(�6(   $��DemiBold"�66   $��4,0,0,0q�6L   $��3��6]   $
 nums��6i   6z   	� 5      -   5        $
 Box4��5      $��14(�6(   $��DemiBold"�66   $��4,0,0,0q�6L   $��4��6]   $
 nums��6i   6z   5      �� 5   
   -   5         ��Name$ confirm��5      $��1q�6"   $��OK��67   $��Center=�6D   $��14(�6a   $��30��6p   $��148,-48,148,0q�6|   $	��Top=�6�   $��90��6�   $��UltraExpanded&�6�   $��DemiBold"�6�    � 	Resources 5       �� 
TargetType �� Property �� Value��%^   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 2��65   5      5      ��5      �� 5      	 �� Color$	 #FFFFFF��6"   
 �� Opacity$

 0.75Q�62   ��5      �� 5      " ��6    �� Triggers 5!      P� 5"       P� Property �@J�IsMouseOver P� Value . . �5#      ��  � ��
 ���� 6;   5$      5&      5(      5)      5*      