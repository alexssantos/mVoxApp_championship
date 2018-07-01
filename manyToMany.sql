alter table team_keygruop
add	CONSTRAINT [FK_Center_Keygroup] FOREIGN KEY ([id_keygroup]) REFERENCES [dbo].[keygroup] ([Id])

alter table team_keygroup
add CONSTRAINT [FK_Center_Team] FOREIGN KEY (id_team) REFERENCES [dbo].[Team] (Id)

