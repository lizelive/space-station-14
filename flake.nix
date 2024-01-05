{
  description = "Development environment for Space Station 14";

  inputs.nixpkgs.url = "github:NixOS/nixpkgs/release-23.11";
  inputs.flake-utils.url = "github:numtide/flake-utils";

  outputs = { self, nixpkgs, flake-utils }:
    flake-utils.lib.eachDefaultSystem (system:
      let
        pkgs = import nixpkgs {
          inherit system;
          config = {
            allowUnfree = true;
            enableOptimizations = true;
          };
        };
      in
      {
        devShells.default = import ./shell.nix { inherit pkgs; };
      });
}
